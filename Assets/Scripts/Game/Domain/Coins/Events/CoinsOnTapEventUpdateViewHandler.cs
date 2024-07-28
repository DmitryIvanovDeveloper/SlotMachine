using System.Threading.Tasks;

using UnityEngine;

namespace SlotMachine.Game.Domain.Coins.Events
{
    public class CoinsOnTapEventUpdateViewHandler
    {
        public Task Handle()
        {
            var coins = Object.FindObjectOfType<Coins>();

            coins.UpdateView();
            return Task.CompletedTask;
        }
    }
}


