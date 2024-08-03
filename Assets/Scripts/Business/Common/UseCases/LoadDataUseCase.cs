using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.Player.UseCases;
using SlotMachine.Business.Domain.Tokens.UseCase;

namespace SlotMachine.Business.Domain.Common.UseCases
{
    public class LoadDataUseCase
    {
        private CoinsLoadDataUseCase _coinsLoadDataUseCase;
        private TokensLoadDataUseCase _tokensLoadDataUseCase;
        private PlayerLoadDataUseCase _playerLoadDataUseCase;

        public LoadDataUseCase(
            CoinsLoadDataUseCase coinsLoadDataUseCase,
            TokensLoadDataUseCase tokensLoadDataUseCase,
            PlayerLoadDataUseCase playerLoadDataUseCase

        )
        {
            _coinsLoadDataUseCase = coinsLoadDataUseCase;
            _tokensLoadDataUseCase = tokensLoadDataUseCase;
            _playerLoadDataUseCase = playerLoadDataUseCase;
        }

        public void Execute()
        {
            _coinsLoadDataUseCase.Execute();
            _tokensLoadDataUseCase.Execute();
            _playerLoadDataUseCase.Execute();
        }
    }
}

