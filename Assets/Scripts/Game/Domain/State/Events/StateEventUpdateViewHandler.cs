using System.Threading.Tasks;
using UnityEngine;

namespace SlotMachine.Game.Domain.State.Events
{
    public class StateEventUpdateViewHandler
    {
        public Task Handle()
        {
            var state = Object.FindObjectOfType<State>();
            state.UpdateView();
            return Task.CompletedTask;
        }
    }
}

