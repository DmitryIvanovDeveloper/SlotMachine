
using SlotMachine.Business.Adapters;

namespace SlotMachine.Business.Domain.Tokens.UseCase
{
    public class TokensLoadDataUseCase
    {
        private ITokens _tokens;
        private IRepository _repository;

        public TokensLoadDataUseCase(
            ITokens tokens,
            IRepository repository
        )
        {
            _tokens = tokens;
            _repository = repository;
        }

        public void Execute()
        {
            var dto = _repository.GetTokens();
            _tokens.Init(dto.Num);
        }
    }
}


