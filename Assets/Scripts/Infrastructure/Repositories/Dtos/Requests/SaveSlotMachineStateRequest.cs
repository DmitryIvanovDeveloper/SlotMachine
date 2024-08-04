using SlotMachine.Business.Common;

namespace SlotMachine.Infrastructure.Repository.Dtos
{
    public class SaveSlotMachineStateRequest
    {
        public StateType StateType { get; set; }
        public byte[] Image { get; set; }
    }
}

