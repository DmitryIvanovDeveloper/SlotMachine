using System.Threading.Tasks;
using SlotMachine.Game.Domain.Coins.Events;

namespace SlotMachine.Game.Domain.CoinSlot.Events
{
    public class CoinSlotReturnCoinEvent
    {
        private CoinSlotReturnCoinsEventExecuteUseCaseHandler _coinSlotReturnCoinsEventExecuteUseCaseHandler;
        private CoinsEventUpdateViewHandler _coinsEventUpdateViewHandler;
        private CoinSlotEventUpdateViewHandler _coinSlotEventUpdateViewHandler;

        public CoinSlotReturnCoinEvent(
            CoinSlotReturnCoinsEventExecuteUseCaseHandler coinSlotReturnCoinsEventExecuteUseCaseHandler,
            CoinsEventUpdateViewHandler coinsEventUpdateViewHandler,
            CoinSlotEventUpdateViewHandler coinSlotEventUpdateViewHandler
        )
        {
            _coinSlotReturnCoinsEventExecuteUseCaseHandler = coinSlotReturnCoinsEventExecuteUseCaseHandler;
            _coinsEventUpdateViewHandler = coinsEventUpdateViewHandler;
            _coinSlotEventUpdateViewHandler = coinSlotEventUpdateViewHandler;
        }

        public Task Notify()
        {
            _coinSlotReturnCoinsEventExecuteUseCaseHandler.Handle();
            _coinsEventUpdateViewHandler.Handle();
            _coinSlotEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}
