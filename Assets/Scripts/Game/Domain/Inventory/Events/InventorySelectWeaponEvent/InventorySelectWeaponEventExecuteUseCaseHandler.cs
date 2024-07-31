using System.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Inventory;

namespace SlotMachine.Game.Domain.Inventory.Events
{
    public class InventorySelectWeaponEventExecuteUseCaseHandler
    {
        private InventorySelectWeaponUseCase _inventorySelectWeaponUseCase;

        public InventorySelectWeaponEventExecuteUseCaseHandler(InventorySelectWeaponUseCase inventorySelectWeaponUseCase)
        {
            _inventorySelectWeaponUseCase = inventorySelectWeaponUseCase;
        }

        public Task Handle(WeaponType weaponType)
        {
            _inventorySelectWeaponUseCase.Execute(weaponType);

            return Task.CompletedTask;
        }
    }
}
