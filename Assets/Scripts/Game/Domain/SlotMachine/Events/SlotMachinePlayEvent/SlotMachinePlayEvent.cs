using System.Threading.Tasks;

namespace SlotMachine.Game.Domain.SlotMachine.Events
{
    public class SlotMachinePlayEvent
    {
        private SlotMachineSlotMachinePlayEventExecuteUseCaseHandler _slotMachineSlotMachinePlayEventExecuteUseCaseHandler;

        public SlotMachinePlayEvent(
            SlotMachineSlotMachinePlayEventExecuteUseCaseHandler slotMachineSlotMachinePlayEventExecuteUseCaseHandler
        )
        {
            _slotMachineSlotMachinePlayEventExecuteUseCaseHandler = slotMachineSlotMachinePlayEventExecuteUseCaseHandler;
        }

        public Task Notify()
        {
            _slotMachineSlotMachinePlayEventExecuteUseCaseHandler.Handle();

            return Task.CompletedTask;
        }
    }
}
