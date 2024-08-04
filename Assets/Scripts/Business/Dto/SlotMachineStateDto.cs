using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Dtos
{
    public class SlotMachineStateDto
    {
        public StateType StateType { get; set; }
        public byte[] Image { get; set; }
    }
};
