using Cysharp.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.State;

namespace SlotMachine.Business.Domain.SlotMachine.UseCase
{
    public class SlotMachinePlayUseCase
    {
        private ISlotMachine _slotMachine;

        private IStateInfo _stateInfo;

        public SlotMachinePlayUseCase(
            ISlotMachine slotMachine,
            IStateInfo stateInfo
        )
        {
            _slotMachine = slotMachine;
            _stateInfo = stateInfo;
        }

        public async UniTask Execute()
        {
            if (_stateInfo.CurrentStateType == StateType.Broken)
            {
                return;
            }

            await _slotMachine.Play();
       
            return;
        }
    }

}

