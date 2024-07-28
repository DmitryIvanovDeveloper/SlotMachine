using System.Threading.Tasks;

namespace SlotMachine.Game.Domain.SlotMachine.Events
{
    public class SlotMachinePlayEvent
    {
        private SlotMachineSlotMachinePlayEventExecuteUseCaseHandler _slotMachineSlotMachinePlayEventExecuteUseCaseHandler;
        private SlotMachineSlotMachinePlayUpdateViewHandler _slotMachineSlotMachinePlayUpdateViewHandler;

        public SlotMachinePlayEvent(
            SlotMachineSlotMachinePlayEventExecuteUseCaseHandler slotMachineSlotMachinePlayEventExecuteUseCaseHandler,
            SlotMachineSlotMachinePlayUpdateViewHandler slotMachineSlotMachinePlayUpdateViewHandler
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
