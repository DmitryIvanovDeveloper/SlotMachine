using SlotMachine.Business.Common;
using System.Collections.Generic;
using static SlotMachine.Business.Domain.Coins.Coins;

namespace SlotMachine.Business.Domain.Coins
{
    public interface ICoinsInfo
    {
        event CoinsChanged OnCoinsChanged;

        Dictionary<CoinType, int> NumCoinsByType { get; }
        int NumCoinsOnTap { get; }
    }
}
