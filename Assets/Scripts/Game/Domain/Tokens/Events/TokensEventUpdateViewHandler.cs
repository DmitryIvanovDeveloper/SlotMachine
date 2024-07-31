using System.Threading.Tasks;
using UnityEngine;

namespace SlotMachine.Game.Domain.Tokens.Events
{
    public class TokensEventUpdateViewHandler
    {
        public Task Handle()
        {
            var tokens = Object.FindObjectOfType<Tokens>();
            tokens.UpdateView();

            return Task.CompletedTask;
        }
    }
}

