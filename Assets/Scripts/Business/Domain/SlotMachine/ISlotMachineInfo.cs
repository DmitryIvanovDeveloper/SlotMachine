using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.SlotMachine
{
    public interface ISlotMachineInfo
    {
        int NumCoinsToPlay { get; }

        int ShapeOneShowInSeconds { get; }
        int ShapeTwoShowInSeconds { get; }
        int ShapeThreeShowInSeconds { get; }

        ShapeType ShapeOne { get; }
        ShapeType ShapeTwo { get; }
        ShapeType ShapeThree { get; }

        int GetPoints();
    }
}

