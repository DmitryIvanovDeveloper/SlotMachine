using System.Threading.Tasks;

namespace SlotMachine.Game.Domain.Tokens.Events
{
    public class TokensAddEvent
    {
        private TokensEventUpdateViewHandler _tokensEventUpdateViewHandler;
        private TokensAddEventExecuteUseCaseHandler _tokensAddEventExecuteUseCaseHandler;

        public TokensAddEvent(
            TokensAddEventExecuteUseCaseHandler tokensAddEventExecuteUseCaseHandler,
            TokensEventUpdateViewHandler tokensEventUpdateViewHandler)
        {
            _tokensAddEventExecuteUseCaseHandler = tokensAddEventExecuteUseCaseHandler;
            _tokensEventUpdateViewHandler = tokensEventUpdateViewHandler;
        }

        public async Task Notify()
        {
            await _tokensAddEventExecuteUseCaseHandler.Handle();
            await _tokensEventUpdateViewHandler.Handle();
        }
    }
}
