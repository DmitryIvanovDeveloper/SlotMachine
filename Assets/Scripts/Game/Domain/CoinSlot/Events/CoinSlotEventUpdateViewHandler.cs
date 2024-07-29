using System.Threading.Tasks;
using UnityEngine;

namespace SlotMachine.Game.Domain.CoinSlot.Events
{
    public class CoinSlotEventUpdateViewHandler
    {
        public Task Handle()
        {
            var coinSlot = Object.FindObjectOfType<CoinSlot>();
            coinSlot.UpdateView();

            return Task.CompletedTask;
        }
    }
}

