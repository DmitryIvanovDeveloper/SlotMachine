using SlotMachine.Business.Common;
using SlotMachine.Game.Domain.CoinSlot.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace SlotMachine.Game.Common
{
    public class Coin : MonoBehaviour
    {
        [field: SerializeField]
        public CoinType CoinType;

        float clicked = 0;
        float clicktime = 0;
        float clickdelay = 0.5f;

        private CoinSlotAddCoinEvent _coinSlotEvent;

        [Inject]
        public void Construct(CoinSlotAddCoinEvent coinSlotEvent)
        {
            _coinSlotEvent = coinSlotEvent;
        }

        public void OnPointerDown()
        {
            clicked++;
            if (clicked == 1)
            {
                clicktime = Time.time;
            }

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                _coinSlotEvent.Notify(CoinType);
            }
            else if (clicked > 2 || Time.time - clicktime > 1)
            {
                clicked = 0;
            };
        }
    }
}
