using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.StageTimer.Events
{
    public class StageTimerStartEventExecuteUseCaseHandler
    {
        private StageTimerStartUseCase _stageTimerStartUseCase;

        public StageTimerStartEventExecuteUseCaseHandler(StageTimerStartUseCase stageTimerStartUseCase)
        {
            _stageTimerStartUseCase = stageTimerStartUseCase;
        }

        public async UniTask Handle()
        {
            await _stageTimerStartUseCase.Execute();
        }
    }
}