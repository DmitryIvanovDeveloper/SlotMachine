
using SlotMachine.Business.Adapters;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Domain.Tokens.UseCase
{
    public class TokensSaveUseCase
    {
        private ITokensInfo _tokensInfo;
        private ILocalStorageRepository _localStorageRepository;

        public TokensSaveUseCase(ITokensInfo tokensInfo, ILocalStorageRepository localStorageRepository)
        {
            _tokensInfo = tokensInfo;
            _localStorageRepository = localStorageRepository;
        }

        public void Execute()
        {
            var dto = new TokensDto()
            {
                Num = _tokensInfo.Num
            };

            _localStorageRepository.SaveTokens(dto);
        }
    }
}


