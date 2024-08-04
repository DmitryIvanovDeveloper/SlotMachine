using System;
using SlotMachine.Business.Common;
using static SlotMachine.Business.Domain.State.State;

namespace SlotMachine.Business.Domain.State
{
    public interface IStateInfo
    {
        event StateChanged OnStateChanged;
        DateTime ChangedStateAt { get; }
        StateType CurrentStateType { get; }
        double HealthInPercentage { get; }
    }
}
