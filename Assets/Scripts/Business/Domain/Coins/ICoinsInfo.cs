using SlotMachine.Business.Common;
using System.Collections.Generic;

namespace SlotMachine.Business.Domain.Coins
{
    public interface ICoinsInfo
    {
        Dictionary<CoinType, int> NumCoinsByType { get; }
        int NumCoinsOnTap { get; }
    }
}
