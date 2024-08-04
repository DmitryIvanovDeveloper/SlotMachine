using System.Collections.Generic;

using SlotMachine.Business.Common;
using UnityEngine;

namespace SlotMachine.Business.Domain.Coins
{
    public class Coins : ICoins, ICoinsInfo
    {
        public delegate void CoinsChanged();
        public event CoinsChanged OnCoinsChanged;

        public Dictionary<CoinType, int> NumCoinsByType { get; private set; } = new Dictionary<CoinType, int>()
        {
            { CoinType.Golden, 0 },
            { CoinType.Silver, 0 },
        };

        public int NumCoinsOnTap { get; private set; } = 1;

        public void Init(int silver, int golden)
        {
            NumCoinsByType[CoinType.Silver] = silver;
            NumCoinsByType[CoinType.Golden] = golden;

            OnCoinsChanged?.Invoke();
        }

        public void Encrease(CoinType coinType)
        {
            NumCoinsByType[coinType] += 1;

            OnCoinsChanged?.Invoke();
        }

        public void Add(CoinType coinType, int num)
        {
            NumCoinsByType[coinType] += num;

            OnCoinsChanged?.Invoke();
        }

        public bool TryDecrease(CoinType coinType, int num)
        {
            if (!NumCoinsByType.ContainsKey(coinType) || NumCoinsByType[coinType] <= 0)
            {
                return false;
            }

            NumCoinsByType[coinType] -= num;

            OnCoinsChanged?.Invoke();

            return true;
        }
    }
}
