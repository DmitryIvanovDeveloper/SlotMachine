using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.Player.UseCases;
using SlotMachine.Business.Domain.Police.UseCases;
using SlotMachine.Business.Domain.StageTimer;
using SlotMachine.Business.Domain.State.UseCase;
using SlotMachine.Business.Domain.Tokens.UseCase;

namespace SlotMachine.Business.Domain.Common.UseCases
{
    public class LoadDataUseCase
    {
        private CoinsLoadDataUseCase _coinsLoadDataUseCase;
        private TokensLoadDataUseCase _tokensLoadDataUseCase;
        private PlayerLoadDataUseCase _playerLoadDataUseCase;
        private StateLoadDataUseCase _stateLoadDataUseCase;
        private StageTimerLoadDataUseCase _stageTimerLoadDataUseCase;
        private PoliceLoadDataUseCase _policeLoadDataUseCase;
        

        public LoadDataUseCase(
            CoinsLoadDataUseCase coinsLoadDataUseCase,
            TokensLoadDataUseCase tokensLoadDataUseCase,
            PlayerLoadDataUseCase playerLoadDataUseCase,
            StateLoadDataUseCase stateLoadDataUseCase,
            StageTimerLoadDataUseCase stageTimerLoadDataUseCase,
            PoliceLoadDataUseCase policeLoadDataUseCase

        )
        {
            _coinsLoadDataUseCase = coinsLoadDataUseCase;
            _tokensLoadDataUseCase = tokensLoadDataUseCase;
            _playerLoadDataUseCase = playerLoadDataUseCase;
            _stateLoadDataUseCase = stateLoadDataUseCase;
            _stageTimerLoadDataUseCase = stageTimerLoadDataUseCase;
            _policeLoadDataUseCase = policeLoadDataUseCase;
        }

        public void Execute()
        {
            _coinsLoadDataUseCase.Execute();
            _tokensLoadDataUseCase.Execute();
            _playerLoadDataUseCase.Execute();
            _stateLoadDataUseCase.Execute();
            _stageTimerLoadDataUseCase.Execute();
            _policeLoadDataUseCase.Execute();
        }
    }
}

