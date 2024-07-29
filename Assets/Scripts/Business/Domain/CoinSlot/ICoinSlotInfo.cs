using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.CoinSlot
{
    public interface ICoinSlotInfo
    {
        CoinType CurrentCoinType { get; }
        int NumCoins { get; }
    }
}
