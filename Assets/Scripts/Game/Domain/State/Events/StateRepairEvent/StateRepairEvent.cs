using System.Threading.Tasks;

namespace SlotMachine.Game.Domain.State.Events
{
    public class StateRepairEvent
    {
        private StateEventUpdateViewHandler _stateEventUpdateViewHandler;
        private StateRepairEventExecuteUseCaseHandler _stateRepairEventExecuteUseCaseHandler;

        public StateRepairEvent(
            StateRepairEventExecuteUseCaseHandler stateRepairEventExecuteUseCaseHandler,
            StateEventUpdateViewHandler stateEventUpdateViewHandler)
        {
            _stateEventUpdateViewHandler = stateEventUpdateViewHandler;
            _stateRepairEventExecuteUseCaseHandler = stateRepairEventExecuteUseCaseHandler;
        }

        public Task Notify()
        {
            _stateRepairEventExecuteUseCaseHandler.Handle();
            _stateEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }

}

