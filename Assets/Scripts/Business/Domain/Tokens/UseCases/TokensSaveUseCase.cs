
using SlotMachine.Business.Adapters;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Domain.Tokens.UseCase
{
    public class TokensSaveUseCase
    {
        private ITokensInfo _tokensInfo;
        private IRepository _repository;

        public TokensSaveUseCase(ITokensInfo tokensInfo, IRepository repository)
        {
            _tokensInfo = tokensInfo;
            _repository = repository;
        }

        public void Execute()
        {
            var dto = new TokensDto()
            {
                Num = _tokensInfo.Num
            };

            _repository.SaveTokens(dto);
        }
    }
}


