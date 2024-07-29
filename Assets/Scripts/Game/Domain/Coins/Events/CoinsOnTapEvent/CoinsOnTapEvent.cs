using System.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Game.Domain.Tokens.Events;

namespace SlotMachine.Game.Domain.Coins.Events
{
    public class CoinsOnTapEvent
    {
        private CoinsOnTapEventExecuteUseCaseHandler _coinsOnTapEventExecuteUseCaseHandler;
        private CoinsEventUpdateViewHandler _coinsOnTapEventUpdateViewHandler;
        private TokensEventUpdateViewHandler _tokensEventUpdateViewHandler;

        public CoinsOnTapEvent(
            CoinsOnTapEventExecuteUseCaseHandler coinsOnTapEventExecuteUseCaseHandler,
            CoinsEventUpdateViewHandler coinsOnTapEventUpdateViewHandler,
            TokensEventUpdateViewHandler tokensEventUpdateViewHandler
        )
        {
            _coinsOnTapEventExecuteUseCaseHandler = coinsOnTapEventExecuteUseCaseHandler;
            _coinsOnTapEventUpdateViewHandler = coinsOnTapEventUpdateViewHandler;
            _tokensEventUpdateViewHandler = tokensEventUpdateViewHandler;
        }

        public Task Notify(CoinType coinType)
        {
            //_coinsOnTapEventExecuteUseCaseHandler.Handle(coinType);
            _coinsOnTapEventUpdateViewHandler.Handle();
            _tokensEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}


