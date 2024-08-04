using System;
using SlotMachine.Infrastructure.Service.Dtos.Responses;

namespace SlotMachine.Infrastructure.Repository.Adapters.Responses
{
    public interface ILevelsResponse
    {
        public Guid LevelId { get; }
        public int TimeInSeconds { get; }
        public int StartPoliceBeforeEndTimeInSeconds { get; }
        public byte[] BackgroundImage { get; }
        public byte[] PreviewImage { get; }
        public SlotMachineResponse SlotMachine { get; }
    }
}

