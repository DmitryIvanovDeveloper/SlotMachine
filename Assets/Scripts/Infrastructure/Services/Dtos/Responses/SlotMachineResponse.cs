using System.Collections.Generic;
using SlotMachine.Infrastructure.Repository.Adapters.Responses;

namespace SlotMachine.Infrastructure.Service.Dtos.Responses
{
    public class SlotMachineResponse : ISlotMachineResponse
    {
        public int FullRepairInMinutes { get; set; }
        public int MaxHealth { get; set; }
        public List<SlotMachineStateResponse> StatesSlotMachine { get; set; }
    }
}
