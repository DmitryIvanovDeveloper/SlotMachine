using System.Threading.Tasks;
using SlotMachine.Business.Domain.State.UseCase;

namespace SlotMachine.Game.Domain.State.Events
{
    public class StateAddDamageEventExecuteUseCaseHandler
    {
        private StateAddDamageUseCase _stateAddDamageUseCase;

        public StateAddDamageEventExecuteUseCaseHandler(StateAddDamageUseCase stateAddDamageUseCase)
        {
            _stateAddDamageUseCase = stateAddDamageUseCase;
        }

        public Task Handle()
        {
            _stateAddDamageUseCase.Execute();
            return Task.CompletedTask;
        }
    }
}

