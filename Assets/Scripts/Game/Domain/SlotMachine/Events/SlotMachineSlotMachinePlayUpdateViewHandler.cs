
using System.Threading.Tasks;

using SlotMachine.Game.Domain.Coins.Events;

namespace SlotMachine.Game.Domain.SlotMachine.Events
{
    public class SlotMachineSlotMachinePlayUpdateViewHandler
    {
        private CoinsOnTapEventUpdateViewHandler _coinsOnTapEventUpdateViewHandler;

        public SlotMachineSlotMachinePlayUpdateViewHandler(CoinsOnTapEventUpdateViewHandler coinsOnTapEventUpdateViewHandler)
        {
            _coinsOnTapEventUpdateViewHandler = coinsOnTapEventUpdateViewHandler;
        }
        public Task Handle()
        {
            _coinsOnTapEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}

