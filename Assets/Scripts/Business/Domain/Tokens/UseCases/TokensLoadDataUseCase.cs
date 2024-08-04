
using SlotMachine.Business.Adapters;

namespace SlotMachine.Business.Domain.Tokens.UseCase
{
    public class TokensLoadDataUseCase
    {
        private ITokens _tokens;
        private ILocalStorageRepository _localStorageRepository;

        public TokensLoadDataUseCase(
            ITokens tokens,
            ILocalStorageRepository localStorageRepository
        )
        {
            _tokens = tokens;
            _localStorageRepository = localStorageRepository;
        }

        public void Execute()
        {
            var dto = _localStorageRepository.GetTokens();
            _tokens.Init(dto.Num);
        }
    }
}


