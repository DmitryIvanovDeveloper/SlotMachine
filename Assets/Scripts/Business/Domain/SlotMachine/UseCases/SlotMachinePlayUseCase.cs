using SlotMachine.Business.Domain.Coins;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Game.Domain.Coins;

namespace SlotMachine.Business.Domain.SlotMachine.UseCase
{
    public class SlotMachinePlayUseCase
    {
        private ISlotMachine _slotMachine;
        private ISlotMachineInfo _slotMachineInfo;

        private ICoins _coins;
        private CoinsAddUseCase _coinsAddUseCase;

        public SlotMachinePlayUseCase(
            ISlotMachine slotMachine,
            ISlotMachineInfo slotMachineInfo,
            ICoins coins,
            CoinsAddUseCase coinsAddUseCase
        )
        {
            _slotMachine = slotMachine;
            _slotMachineInfo = slotMachineInfo;
            _coins = coins;
            _coinsAddUseCase = coinsAddUseCase;
        }

        public bool Execute()
        {
            var canPlay = _slotMachine.Play(_coins);
            if (!canPlay)
            {
                return canPlay;
            }

            _coinsAddUseCase.Execute(_slotMachineInfo.GetPoints());

            return canPlay;
        }
    }

}

