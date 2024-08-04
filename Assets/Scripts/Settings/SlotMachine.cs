using System.Collections.Generic;
using UnityEngine;

using SlotMachine.Settings.Dtos;

namespace SlotMachine.Settings
{
    [CreateAssetMenu(fileName = "SlotMachine", menuName = "ScriptableObjects/SlotMachine", order = 1)]
    public class SlotMachine : ScriptableObject
    {
        [field: SerializeField]
        public int FullRepairInMinutes { get; private set; }
        [field: SerializeField]
        public int MaxHealth { get; private set; }
        [field: SerializeField]
        public List<StateImage> StateImages { get; private set; }

        public SlotMachineDto GetDto()
        {
            var slotMachineDto = new SlotMachineDto()
            {
                FullRepairInMinutes = FullRepairInMinutes,
                MaxHealth = MaxHealth,
            };

            foreach(var image in StateImages)
            {
                var dto = new StateSlotMachineDto()
                {
                    StateType = image.StateType,
                    Image = image.Image.EncodeToPNG(),
                };

                slotMachineDto.StatesSlotMachine.Add(dto);
            }

            return slotMachineDto;
        }
    }
}

