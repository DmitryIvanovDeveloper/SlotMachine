using SlotMachine.Business.Common;

namespace SlotMachine.Infrastructure.Repository.Adapters.Responses
{
    public interface ISlotMachineStateResponse
    {
        public StateType StateType { get; set; }
        public byte[] Image { get; set; }
    }
}


