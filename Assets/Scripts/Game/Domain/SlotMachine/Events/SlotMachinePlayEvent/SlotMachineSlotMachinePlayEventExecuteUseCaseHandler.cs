using System.Threading.Tasks;
using UnityEngine;

using SlotMachine.Business.Domain.SlotMachine.UseCase;

namespace SlotMachine.Game.Domain.SlotMachine.Events
{
    public class SlotMachineSlotMachinePlayEventExecuteUseCaseHandler
    {
        private SlotMachinePlayUseCase _slotMachineGetShapesUseCase;

        public SlotMachineSlotMachinePlayEventExecuteUseCaseHandler(SlotMachinePlayUseCase slotMachineGetShapesUseCase)
        {
            _slotMachineGetShapesUseCase = slotMachineGetShapesUseCase;
        }

        public Task Handle()
        {
            var isSuccess = _slotMachineGetShapesUseCase.Execute();
            if (!isSuccess)
            {
                return Task.CompletedTask;
            }

            var slotMachine = Object.FindObjectOfType<SlotMachine>();

            slotMachine.StartGame();
            return Task.CompletedTask;
        }
    }
}

