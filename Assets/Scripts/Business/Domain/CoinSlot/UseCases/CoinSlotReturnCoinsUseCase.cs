using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.State;

namespace SlotMachine.Business.Domain.CoinSlot.UseCases
{
    public class CoinSlotReturnCoinsUseCase
    {
        private ICoinSlot _coinSlot;
        private IStateInfo _stateInfo;

        public CoinSlotReturnCoinsUseCase(ICoinSlot coinSlot, IStateInfo stateInfo)
        {
            _coinSlot = coinSlot;
            _stateInfo = stateInfo;
        }

        public void Execute()
        {
            if (_stateInfo.CurrentStateType == StateType.Broken)
            {
                return;
            }

            _coinSlot.ReturnCoins();
        }
    }
}
