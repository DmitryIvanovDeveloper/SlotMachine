using System;
using SlotMachine.Infrastructure.Repository.Adapters.Responses;

namespace SlotMachine.Infrastructure.Service.Dtos.Responses
{
    public class LevelsResponse : ILevelsResponse
    {
        public Guid LevelId { get; set; }
        public int TimeInSeconds { get; set; }
        public int StartPoliceBeforeEndTimeInSeconds { get; set; }
        public byte[] BackgroundImage { get; set; }
        public byte[] PreviewImage { get; set; }
        public SlotMachineResponse SlotMachine { get; set; }
    }
}