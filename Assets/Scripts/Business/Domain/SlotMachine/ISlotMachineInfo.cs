using SlotMachine.Business.Common;
using static SlotMachine.Business.Domain.SlotMachine.SlotMachine;

namespace SlotMachine.Business.Domain.SlotMachine
{
    public interface ISlotMachineInfo
    {
        event SlotChanged OnSlostChanged;
        event StartGame OnStartGame;

        int ShapeOneShowInSeconds { get; }
        int ShapeTwoShowInSeconds { get; }
        int ShapeThreeShowInSeconds { get; }

        ShapeType ShapeOne { get; }
        ShapeType ShapeTwo { get; }
        ShapeType ShapeThree { get; }

        int GetPoints();
    }
}

