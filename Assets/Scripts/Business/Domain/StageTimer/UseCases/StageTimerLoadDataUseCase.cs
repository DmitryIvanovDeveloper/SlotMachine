using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.StageTimer
{
    public class StageTimerLoadDataUseCase
    {
        private IStageTimer _stageTimer;
        private IBusinessContext _businessContext;

        public StageTimerLoadDataUseCase(IBusinessContext businessContext, IStageTimer stageTimer)
        {
            _stageTimer = stageTimer;
            _businessContext = businessContext;
        }

        public void Execute()
        {
            _stageTimer.Init(_businessContext.TimeInSeconds);
        }
    }
}


