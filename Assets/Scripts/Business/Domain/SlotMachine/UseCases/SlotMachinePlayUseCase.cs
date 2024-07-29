using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.State;

namespace SlotMachine.Business.Domain.SlotMachine.UseCase
{
    public class SlotMachinePlayUseCase
    {
        private ISlotMachine _slotMachine;
        private ISlotMachineInfo _slotMachineInfo;

        private ICoins _coins;
        private CoinsAddUseCase _coinsAddUseCase;
        private IStateInfo _stateInfo;

        public SlotMachinePlayUseCase(
            ISlotMachine slotMachine,
            ISlotMachineInfo slotMachineInfo,
            ICoins coins,
            IStateInfo stateInfo,
            CoinsAddUseCase coinsAddUseCase
        )
        {
            _slotMachine = slotMachine;
            _slotMachineInfo = slotMachineInfo;
            _coins = coins;
            _coinsAddUseCase = coinsAddUseCase;
            _stateInfo = stateInfo;
        }

        public bool Execute()
        {
            if (_stateInfo.CurrentStateType == StateType.Broken)
            {
                return false;
            }

            var canPlay = _slotMachine.Play();
            if (!canPlay)
            {
                return canPlay;
            }

            _coinsAddUseCase.Execute(CoinType.Silver, _slotMachineInfo.GetPoints());

            return canPlay;
        }
    }

}

