using System;

namespace SlotMachine.Settings.Dtos
{
    public class LevelDto
    {
        public Guid LevelId { get; set; }
        public int TimeInSeconds { get; set; }
        public int StartPoliceBeforeEndTimeInSeconds { get; set; }
        public byte[] BackgroundImage { get; set; }
        public byte[] PreviewImage { get; set; }
        public SlotMachineDto SlotMachine { get; set; }
    }
}

