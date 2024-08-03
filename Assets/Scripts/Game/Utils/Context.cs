using SlotMachine.Business.Common;
using SlotMachine.Game.Common;
using SlotMachine.Settings;

public class Context : IGameContext, IBusinessContext
{
    public int TimeInSeconds { get; set; }

    public int StartPoliceBeforeEndTime { get; set; }

    public int SlotMachineMaxHealth { get; set; }

    public int SlotMachineFullRepairInMinutes { get; set; }

    public Level Level { get; set; }
}

