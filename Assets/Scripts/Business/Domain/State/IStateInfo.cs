﻿using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.State
{
    public interface IStateInfo
    {
        StateType CurrentStateType { get; }
        double CurrentRepairInPercentage { get; }
    }
}