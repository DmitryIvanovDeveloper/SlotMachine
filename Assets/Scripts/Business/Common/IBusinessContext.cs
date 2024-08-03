namespace SlotMachine.Business.Common
{
    public interface IBusinessContext
    {
        int TimeInSeconds { get; }
        int StartPoliceBeforeEndTime { get; }
        int SlotMachineMaxHealth { get; }
        int SlotMachineFullRepairInMinutes { get; }
    }
}

