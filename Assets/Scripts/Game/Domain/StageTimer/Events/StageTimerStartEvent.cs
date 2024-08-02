using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.StageTimer.Events
{
    public class StageTimerStartEvent
    {
        private StageTimerStartEventExecuteUseCaseHandler _stageTimerEventExecuteUseCaseHandler;

        public StageTimerStartEvent(StageTimerStartEventExecuteUseCaseHandler stageTimerEventExecuteUseCaseHandler)
        {
            _stageTimerEventExecuteUseCaseHandler = stageTimerEventExecuteUseCaseHandler;
        }

        public async UniTask Notify()
        {
            await _stageTimerEventExecuteUseCaseHandler.Handle();
        }
    }
}
