using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Coins
{
    public interface ICoins
    {
        void Encrease(CoinType coinType);
        bool TryDecrease(CoinType coinType, int num);
        void Add(CoinType coinType, int num);
    }
}


