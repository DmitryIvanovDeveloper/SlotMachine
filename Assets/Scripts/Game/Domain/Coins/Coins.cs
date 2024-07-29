using UnityEngine;
using Zenject;
using TMPro;

using SlotMachine.Game.Domain.Coins.Events;
using SlotMachine.Business.Domain.Coins;
using System.Collections;
using SlotMachine.Business.Domain.SlotMachine;
using SlotMachine.Business.Common;

namespace SlotMachine.Game.Domain.Coins
{
    public class Coins : MonoBehaviour
    {
        private int _numCoins;


        [SerializeField]
        private AudioSource _audioSource;


        [SerializeField]
        private TextMeshProUGUI _coins;

        private ICoinsInfo _coinsInfo;
        private CoinsOnTapEvent _coinsOnTapEvent;
        private ISlotMachineInfo _slotMachineInfo;

        [Inject]
        public void Construct(ICoinsInfo coinsInfo, CoinsOnTapEvent coinsOnTapEvent, ISlotMachineInfo slotMachineInfo)
        {
            _coinsInfo = coinsInfo;
            _coinsOnTapEvent = coinsOnTapEvent;
            _slotMachineInfo = slotMachineInfo;
        }

        public void UpdateView()
        {
            var numSilverCoins = _coinsInfo.NumCoinsByType[CoinType.Silver];

            if (numSilverCoins > _numCoins)
            {
                _audioSource.PlayOneShot(_audioSource.clip);
            }

            if (_numCoins > numSilverCoins)
            {
                _numCoins = numSilverCoins;
                _coins.text = $"{_numCoins}";
                return;
            }

            if (_numCoins + _coinsInfo.NumCoinsOnTap == numSilverCoins)
            {
                _numCoins = numSilverCoins;
                _coins.text = $"{_numCoins}";

                return;
            }

            _numCoins = numSilverCoins;

            StartCoroutine(EcreaseCoinsWithDelay());
        }

        private IEnumerator EcreaseCoinsWithDelay()
        {
            yield return new WaitForSeconds(_slotMachineInfo.ShapeThreeShowInSeconds);

            _coins.text = $"{_numCoins}";
        }

        public async void OnTap()
        {
            await _coinsOnTapEvent.Notify(CoinType.Silver);
        }
    }
}
