using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.State.UseCase
{
    public class StateLoadDataUseCase
    {
        private IState _state;
        private IBusinessContext _businessContext;

        public StateLoadDataUseCase(IState state, IBusinessContext businessContext)
        {
            _state = state;
            _businessContext = businessContext;
        }

        public void Execute()
        {
            _state.Init(_businessContext.SlotMachineMaxHealth, _businessContext.SlotMachineFullRepairInMinutes);
        }
    }
}

