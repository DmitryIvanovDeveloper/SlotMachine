using SlotMachine.Business.Domain.Coins;

namespace SlotMachine.Business.Domain.SlotMachine
{
    public interface ISlotMachine
    {
        bool Play(ICoins coins);
    }
}

