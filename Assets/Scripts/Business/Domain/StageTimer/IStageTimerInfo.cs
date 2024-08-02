using System;
using static SlotMachine.Business.Domain.StageTimer.StageTimer;

namespace SlotMachine.Business.Domain.StageTimer
{
    public interface IStageTimerInfo
    {
        event Update OnUpdate;

        TimeSpan CurrentTime { get; }
        string GetLeftTime();
    }
}


