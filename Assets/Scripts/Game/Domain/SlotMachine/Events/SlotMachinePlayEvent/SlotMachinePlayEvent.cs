using System.Threading.Tasks;

namespace SlotMachine.Game.Domain.SlotMachine.Events
{
    public class SlotMachinePlayEvent
    {
        private SlotMachineSlotMachinePlayEventExecuteUseCaseHandler _slotMachineSlotMachinePlayEventExecuteUseCaseHandler;
        private SlotMachineEventUpdateViewHandler _slotMachineSlotMachinePlayUpdateViewHandler;

        public SlotMachinePlayEvent(
            SlotMachineSlotMachinePlayEventExecuteUseCaseHandler slotMachineSlotMachinePlayEventExecuteUseCaseHandler,
            SlotMachineEventUpdateViewHandler slotMachineSlotMachinePlayUpdateViewHandler
        )
        {
            _slotMachineSlotMachinePlayEventExecuteUseCaseHandler = slotMachineSlotMachinePlayEventExecuteUseCaseHandler;
            _slotMachineSlotMachinePlayUpdateViewHandler = slotMachineSlotMachinePlayUpdateViewHandler;
        }

        public Task Notify()
        {
            _slotMachineSlotMachinePlayEventExecuteUseCaseHandler.Handle();
            _slotMachineSlotMachinePlayUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}
