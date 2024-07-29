using System.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;

namespace SlotMachine.Game.Domain.Coins.Events
{
    public class CoinsOnTapEventExecuteUseCaseHandler
    {
        private CoinsEncreaseUseCase _coinsEncreaseUseCase;

        public CoinsOnTapEventExecuteUseCaseHandler(CoinsEncreaseUseCase coinsEncreaseUseCase)
        {
            _coinsEncreaseUseCase = coinsEncreaseUseCase;
        }

        public Task Handle(CoinType coinType)
        {
            _coinsEncreaseUseCase.Execute(coinType);
            return Task.CompletedTask;
        }
    }
}


