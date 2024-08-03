using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.State;

namespace SlotMachine.Business.Domain.CoinSlot.UseCases
{
    public class CoinSlotTryDecreaseCoinsUseCase
    {
        private ICoinSlot _coinSlot;
        private IStateInfo _stateInfo;

        public CoinSlotTryDecreaseCoinsUseCase(ICoinSlot coinSlot, IStateInfo stateInfo)
        {
            _coinSlot = coinSlot;
            _stateInfo = stateInfo;
        }

        public (CoinType, bool) Execute()
        {
            return _coinSlot.TryDecreaseCoins();
        }
    }
}
