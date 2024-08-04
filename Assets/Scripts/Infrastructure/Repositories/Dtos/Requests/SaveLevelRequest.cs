using System;

namespace SlotMachine.Infrastructure.Repository.Dtos
{
    public class SaveLevelRequest
    {
        public Guid LevelId { get; set; }
        public int TimeInSeconds { get; set; }
        public int StartPoliceBeforeEndTimeInSeconds { get; set; }
        public byte[] BackgroundImage { get; set; }
        public byte[] PreviewImage { get; set; }
        public SaveSlotMachineRequest SlotMachine { get; set; }
    }
}
