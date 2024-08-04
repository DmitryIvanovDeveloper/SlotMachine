using System.Collections.Generic;

namespace SlotMachine.Infrastructure.Repository.Dtos
{
    public class SaveSlotMachineRequest
    {
        public int FullRepairInMinutes { get; set; }
        public int MaxHealth { get; set; }
        public List<SaveSlotMachineStateRequest> StatesSlotMachine { get; set; } = new List<SaveSlotMachineStateRequest>();
    }
}

