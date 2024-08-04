using System.Collections.Generic;
using SlotMachine.Infrastructure.Service.Dtos.Responses;

namespace SlotMachine.Infrastructure.Repository.Adapters.Responses
{
    public interface ISlotMachineResponse
    {
        public int FullRepairInMinutes { get; }
        public int MaxHealth { get; }
        public List<SlotMachineStateResponse> StatesSlotMachine { get; }
    }
}
