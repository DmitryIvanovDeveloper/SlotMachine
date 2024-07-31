using System.Threading.Tasks;

namespace SlotMachine.Game.Domain.State.Events
{
    public class StateAddDamageEvent
    {
        private StateAddDamageEventExecuteUseCaseHandler _stateAddDamageEventExecuteUseCaseHandler;
        private StateEventUpdateViewHandler _stateEventUpdateViewHandler;

        public StateAddDamageEvent(
            StateAddDamageEventExecuteUseCaseHandler stateAddDamageEventExecuteUseCaseHandler,
            StateEventUpdateViewHandler stateEventUpdateViewHandler
        )
        {
            _stateAddDamageEventExecuteUseCaseHandler = stateAddDamageEventExecuteUseCaseHandler;
            _stateEventUpdateViewHandler = stateEventUpdateViewHandler;
        }

        public Task Notify()
        {
            _stateAddDamageEventExecuteUseCaseHandler.Handle();
            _stateEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}

