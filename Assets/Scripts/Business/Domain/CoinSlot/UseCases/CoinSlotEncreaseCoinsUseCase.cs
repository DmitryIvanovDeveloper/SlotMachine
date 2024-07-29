using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.CoinSlot.UseCases
{
    public class CoinSlotEncreaseCoinsUseCase
    {
        private ICoinSlot _coinSlot;

        public CoinSlotEncreaseCoinsUseCase(ICoinSlot coinSlot)
        {
            _coinSlot = coinSlot;
        }

        public bool Execute(CoinType coinType)
        {
            return _coinSlot.TryEncrease(coinType);
        }
    }
}
