using System.Collections.Generic;

using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Coins
{
    public class Coins : ICoins, ICoinsInfo
    {
        public Dictionary<CoinType, int> NumCoinsByType { get; private set; } = new Dictionary<CoinType, int>()
        {
            { CoinType.Golden, 0 },
            { CoinType.Silver, 0 },
        };

        public int NumCoinsOnTap { get; private set; } = 1;

        public void Encrease(CoinType coinType)
        {
            NumCoinsByType[coinType] += 1;
        }

        public void Add(CoinType coinType, int num)
        {
            NumCoinsByType[coinType] += num;
        }

        public bool TryDecrease(CoinType coinType, int num)
        {
            if (!NumCoinsByType.ContainsKey(coinType) || NumCoinsByType[coinType] <= 0)
            {
                return false;
            }

            NumCoinsByType[coinType] -= num;

            return true;
        }
    }
}
