using SlotMachine.Business.Common;
using static SlotMachine.Business.Domain.CoinSlot.CoinSlot;

namespace SlotMachine.Business.Domain.CoinSlot
{
    public interface ICoinSlotInfo
    {
        event CoinsSlotChanged OnCoinsSlotChanged;

        CoinType CurrentCoinType { get; }
        int NumCoins { get; }
    }
}
