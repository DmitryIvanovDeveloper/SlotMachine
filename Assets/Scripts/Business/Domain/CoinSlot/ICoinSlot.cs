using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.CoinSlot
{
    public interface ICoinSlot
    {
        bool TryEncrease(CoinType coinType);
        bool HasCoins(CoinType coinType);
        (CoinType, int) TakeCoins();
        void ReturnCoins();
    }
}
