using System;
using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Dtos
{
    public class StateDto
    {
        public StateType StateType { get; set; }
        public DateTime ChangedStateAt { get; set; }
    }
}
