using SlotMachine.Business.Common;

namespace SlotMachine.Settings.Dtos
{
    public class StateSlotMachineDto
    {
        public StateType StateType { get; set; }
        public byte[] Image { get; set; }
    }
}

