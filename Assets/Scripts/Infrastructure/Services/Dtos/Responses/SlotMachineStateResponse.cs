using SlotMachine.Business.Common;
using SlotMachine.Infrastructure.Repository.Adapters.Responses;

namespace SlotMachine.Infrastructure.Service.Dtos.Responses
{
    public class SlotMachineStateResponse : ISlotMachineStateResponse
    {
        public StateType StateType { get; set; }
        public byte[] Image { get; set; }
    }
}


