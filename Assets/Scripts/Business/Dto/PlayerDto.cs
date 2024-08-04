using System;

namespace SlotMachine.Business.Domain.Dtos
{
    public class PlayerDto
    {
        public bool IsArrested { get; set; }
        public DateTime ArrestedAt { get; set; }
    }
}
