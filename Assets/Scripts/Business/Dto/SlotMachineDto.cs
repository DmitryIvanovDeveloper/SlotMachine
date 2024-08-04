using System.Collections.Generic;

namespace SlotMachine.Business.Domain.Dtos
{
    public class SlotMachineDto
    {
        public int FullRepairInMinutes { get; set; }

        public int MaxHealth { get; set; }

        public List<SlotMachineStateDto> StatesSlotMachine { get; set; } = new List<SlotMachineStateDto>();
    }
};
