using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.StageTimer
{
    public class StageTimerStartUseCase
    {
        private IStageTimer _stageTimer;

        public StageTimerStartUseCase(IStageTimer stageTimer)
        {
            _stageTimer = stageTimer;
        }

        public async UniTask Execute()
        {
            await _stageTimer.Start();
        }
    }
}


