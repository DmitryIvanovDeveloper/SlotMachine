namespace SlotMachine.Business.Domain.StageTimer
{
    public class StageTimerStopUseCase
    {
        private IStageTimer _stageTimer;

        public StageTimerStopUseCase(IStageTimer stageTimer)
        {
            _stageTimer = stageTimer;
        }

        public void Execute()
        {
            _stageTimer.Stop();
        }
    }
}


