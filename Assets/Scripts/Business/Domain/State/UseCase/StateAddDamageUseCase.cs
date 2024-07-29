using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.State.UseCase
{
    public class StateAddDamageUseCase
    {
        private IState _state;
        private IStateInfo _stateInfo;

        public StateAddDamageUseCase(IState state, IStateInfo stateInfo)
        {
            _state = state;
            _stateInfo = stateInfo;
        }

        public void Execute()
        {
            if (_stateInfo.CurrentStateType == StateType.Broken)
            {
                return;
            }

            _state.AddDamage();
        }
    }
}

