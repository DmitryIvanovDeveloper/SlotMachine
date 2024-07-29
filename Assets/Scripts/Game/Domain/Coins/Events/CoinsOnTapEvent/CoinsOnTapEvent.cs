using System.Threading.Tasks;
using SlotMachine.Business.Common;

namespace SlotMachine.Game.Domain.Coins.Events
{
    public class CoinsOnTapEvent
    {
        private CoinsOnTapEventExecuteUseCaseHandler _coinsOnTapEventExecuteUseCaseHandler;
        private CoinsEventUpdateViewHandler _coinsOnTapEventUpdateViewHandler;

        public CoinsOnTapEvent(
            CoinsOnTapEventExecuteUseCaseHandler coinsOnTapEventExecuteUseCaseHandler,
            CoinsEventUpdateViewHandler coinsOnTapEventUpdateViewHandler
        )
        {
            _coinsOnTapEventExecuteUseCaseHandler = coinsOnTapEventExecuteUseCaseHandler;
            _coinsOnTapEventUpdateViewHandler = coinsOnTapEventUpdateViewHandler;
        }

        public Task Notify(CoinType coinType)
        {
            _coinsOnTapEventExecuteUseCaseHandler.Handle(coinType);
            _coinsOnTapEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}


