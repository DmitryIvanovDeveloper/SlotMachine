using System.Threading.Tasks;

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

        public Task Handle()
        {
            _coinsEncreaseUseCase.Execute();
            return Task.CompletedTask;
        }
    }
}


