namespace SlotMachine.Business.Domain.CoinSlot.UseCases
{
    public class CoinSlotReturnCoinsUseCase
    {
        private ICoinSlot _coinSlot;

        public CoinSlotReturnCoinsUseCase(ICoinSlot coinSlot)
        {
            _coinSlot = coinSlot;
        }

        public void Execute()
        {
            _coinSlot.ReturnCoins();
        }
    }
}
