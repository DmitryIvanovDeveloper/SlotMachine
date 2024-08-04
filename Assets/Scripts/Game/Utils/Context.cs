using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Dtos;
using SlotMachine.Game.Common;

public class Context : IGameContext, IBusinessContext
{
    public int TimeInSeconds { get; set; }

    public int StartPoliceBeforeEndTime { get; set; }

    public int SlotMachineMaxHealth { get; set; }

    public int SlotMachineFullRepairInMinutes { get; set; }

    public LevelDto Level { get; set; }
}

