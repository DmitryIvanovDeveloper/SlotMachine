using System.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.Tokens.UseCase;

namespace SlotMachine.Game.Domain.Coins.Events
{
    public class CoinsOnTapEventExecuteUseCaseHandler
    {
        private CoinsEncreaseUseCase _coinsEncreaseUseCase;
        private TokensAddUseCase _tokensAddUseCase;

        public CoinsOnTapEventExecuteUseCaseHandler(
            CoinsEncreaseUseCase coinsEncreaseUseCase,
            TokensAddUseCase tokensAddUseCase
        )
        {
            _coinsEncreaseUseCase = coinsEncreaseUseCase;
            _tokensAddUseCase = tokensAddUseCase;
        }

        public Task Handle(CoinType coinType)
        {
            _coinsEncreaseUseCase.Execute(coinType);
            _tokensAddUseCase.Execute();

            return Task.CompletedTask;
        }
    }
}


