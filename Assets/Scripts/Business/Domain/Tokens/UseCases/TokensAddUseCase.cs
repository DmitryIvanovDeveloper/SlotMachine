
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.State;

namespace SlotMachine.Business.Domain.Tokens.UseCase
{
    public class TokensAddUseCase
    {
        private ITokens _tokens;
        private IStateInfo _stateInfo;

        public TokensAddUseCase(ITokens tokens, IStateInfo stateInfo)
        {
            _tokens = tokens;
            _stateInfo = stateInfo;
        }

        public void Execute()
        {
            if (_stateInfo.CurrentStateType == StateType.Broken)
            {
                return;
            }

            _tokens.Add(1);
        }
    }
}


