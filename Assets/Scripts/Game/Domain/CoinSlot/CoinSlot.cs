using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System.Collections.Generic;

using SlotMachine.Game.Common;
using SlotMachine.Game.Domain.CoinSlot.Events;
using SlotMachine.Game.Util.Extensions;
using SlotMachine.Business.Domain.CoinSlot;
using TMPro;
using SlotMachine.Business.Common;
using SlotMacchine.Game.Domain.Utils;

namespace SlotMachine.Game.Domain.CoinSlot
{
    public class CoinSlot : MonoBehaviour
    {
        private int _numCoins;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private List<Sprite> _coins;

        [SerializeField]
        private Image _coin;
        [SerializeField]
        private TextMeshProUGUI _num;

        private ICoinSlotInfo _coinSlotInfo;
        private CoinSlotReturnCoinEvent _coinSlotReturnCoinEvent;
        private CoinSlotAddCoinEvent _coinSlotEvent;

        private CoinType _cointType;

        [Inject]
        public void Construct
            (ICoinSlotInfo coinSlotInfo,
            CoinSlotAddCoinEvent coinSlotEvent,
            CoinSlotReturnCoinEvent coinSlotReturnCoinEvent
        )
        {
            _coinSlotInfo = coinSlotInfo;
            _coinSlotEvent = coinSlotEvent;
            _coinSlotReturnCoinEvent = coinSlotReturnCoinEvent;
        }

        public void UpdateView()
        {
            _coin.sprite = _coinSlotInfo.CurrentCoinType == Business.Common.CoinType.Golden
                ? _coins[0]
                : _coins[1]
            ;

            if (_numCoins < _coinSlotInfo.NumCoins)
            {
                _audioSource.PlayOneShot(_audioSource.clip);
            }

            _numCoins = _coinSlotInfo.NumCoins;
            _num.text = $"{_coinSlotInfo.NumCoins}";
        }

        public void ReturnCoins()
        {
            _coinSlotReturnCoinEvent.Notify();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out Coin coin))
            {
                _coinSlotEvent.Notify(coin.CoinType);

                var dragAndDrop = collision.transform.GetComponentOrThrow<DragAndDrop>();

                dragAndDrop.OnMouseUp();
            }

        }
    }
}
