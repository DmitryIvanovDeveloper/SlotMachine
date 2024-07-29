using System.Threading.Tasks;

using SlotMachine.Business.Domain.State.UseCase;

namespace SlotMachine.Game.Domain.State.Events
{
    public class StateRepairEventExecuteUseCaseHandler
    {
        private StateRepairUseCase _stateRepairUseCase;

        public StateRepairEventExecuteUseCaseHandler(StateRepairUseCase stateRepairUseCase)
        {
            _stateRepairUseCase = stateRepairUseCase;
        }

        public Task Handle()
        {
            _stateRepairUseCase.Execute();

            return Task.CompletedTask;
        }
    }
}

