using System.Threading.Tasks;
using SlotMachine.Business.Domain.Tokens.UseCase;

namespace SlotMachine.Game.Domain.Tokens.Events
{
    public class TokensAddEventExecuteUseCaseHandler
    {
        private TokensAddUseCase _tokensAddUseCase;

        public TokensAddEventExecuteUseCaseHandler(TokensAddUseCase tokensAddUseCase)
        {
            _tokensAddUseCase = tokensAddUseCase;
        }

        public Task Handle()
        {
            _tokensAddUseCase.Execute();

            return Task.CompletedTask;
        }
    }
}
