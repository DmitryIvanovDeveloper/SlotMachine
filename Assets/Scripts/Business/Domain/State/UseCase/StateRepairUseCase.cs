namespace SlotMachine.Business.Domain.State.UseCase
{
    public class StateRepairUseCase
    {
        private IState _state;

        public StateRepairUseCase(IState state)
        {
            _state = state;
        }

        public void Execute()
        {
            _state.Repair();
        }
    }
}

