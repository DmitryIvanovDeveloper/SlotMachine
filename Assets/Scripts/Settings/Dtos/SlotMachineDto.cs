using System.Collections.Generic;

namespace SlotMachine.Settings.Dtos
{
    public class SlotMachineDto
    {
        public int FullRepairInMinutes { get; set; }
        public int MaxHealth { get; set; }
        public List<StateSlotMachineDto> StatesSlotMachine { get; set; } = new List<StateSlotMachineDto>();
    }
}

