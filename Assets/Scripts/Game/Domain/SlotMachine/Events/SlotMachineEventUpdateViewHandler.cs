using System.Threading.Tasks;

using SlotMachine.Game.Domain.Coins.Events;
using SlotMachine.Game.Domain.CoinSlot.Events;

namespace SlotMachine.Game.Domain.SlotMachine.Events
{
    public class SlotMachineEventUpdateViewHandler
    {
        private CoinsEventUpdateViewHandler _coinsOnTapEventUpdateViewHandler;
        private CoinSlotEventUpdateViewHandler _coinSlotEventUpdateViewHandler;

        public SlotMachineEventUpdateViewHandler(
            CoinsEventUpdateViewHandler coinsOnTapEventUpdateViewHandler,
            CoinSlotEventUpdateViewHandler coinSlotEventUpdateViewHandler
        )
        {
            _coinsOnTapEventUpdateViewHandler = coinsOnTapEventUpdateViewHandler;
            _coinSlotEventUpdateViewHandler = coinSlotEventUpdateViewHandler;
        }
        public Task Handle()
        {
            _coinsOnTapEventUpdateViewHandler.Handle();
            _coinSlotEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}