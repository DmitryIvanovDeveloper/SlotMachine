using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.CoinSlot
{
    public interface ICoinSlot
    {
        bool TryEncrease(CoinType coinType);
        (CoinType, bool) TryDecreaseCoins();
        void ReturnCoins();
    }
}
