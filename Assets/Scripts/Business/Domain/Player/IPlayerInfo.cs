using System;
using static SlotMachine.Business.Domain.Player.Player;

namespace SlotMachine.Business.Domain.Player
{
    public interface IPlayerInfo
    {
        event ArrestTimerUpdate OnArrestTimerUpdate;

        bool IsArrested { get; }
        DateTime ArrestedAt { get; }
        string GetLiftArrestTime();
    }
}

