using System.Threading.Tasks;

namespace SlotMachine.Game.Domain.Coins.Events
{
    public class CoinsOnTapEvent
    {
        private CoinsOnTapEventExecuteUseCaseHandler _coinsOnTapEventExecuteUseCaseHandler;
        private CoinsOnTapEventUpdateViewHandler _coinsOnTapEventUpdateViewHandler;

        public CoinsOnTapEvent(
            CoinsOnTapEventExecuteUseCaseHandler coinsOnTapEventExecuteUseCaseHandler,
            CoinsOnTapEventUpdateViewHandler coinsOnTapEventUpdateViewHandler
        )
        {
            _coinsOnTapEventExecuteUseCaseHandler = coinsOnTapEventExecuteUseCaseHandler;
            _coinsOnTapEventUpdateViewHandler = coinsOnTapEventUpdateViewHandler;
        }

        public Task Notify()
        {
            _coinsOnTapEventExecuteUseCaseHandler.Handle();
            _coinsOnTapEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}


