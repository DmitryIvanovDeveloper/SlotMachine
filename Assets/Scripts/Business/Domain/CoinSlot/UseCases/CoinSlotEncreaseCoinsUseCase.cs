using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.State;
using UnityEngine;

namespace SlotMachine.Business.Domain.CoinSlot.UseCases
{
    public class CoinSlotEncreaseCoinsUseCase
    {
        private ICoinSlot _coinSlot;
        private IStateInfo _stateInfo;

        public CoinSlotEncreaseCoinsUseCase(ICoinSlot coinSlot, IStateInfo stateInfo)
        {
            _coinSlot = coinSlot;
            _stateInfo = stateInfo;
        }

        public bool Execute(CoinType coinType)
        {
            if (_stateInfo.CurrentStateType == StateType.Broken)
            {
                return false;
            }

            return _coinSlot.TryEncrease(coinType);
        }
    }
}
