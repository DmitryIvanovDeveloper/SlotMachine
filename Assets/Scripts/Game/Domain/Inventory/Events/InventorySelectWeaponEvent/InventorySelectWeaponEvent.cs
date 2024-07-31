using System.Threading.Tasks;
using SlotMachine.Business.Common;

namespace SlotMachine.Game.Domain.Inventory.Events
{
    public class InventorySelectWeaponEvent
    {
        private InventorySelectWeaponEventExecuteUseCaseHandler _inventorySelectWeaponEventExecuteUseCaseHandler;

        public InventorySelectWeaponEvent(InventorySelectWeaponEventExecuteUseCaseHandler inventorySelectWeaponEventExecuteUseCaseHandler)
        {
            _inventorySelectWeaponEventExecuteUseCaseHandler = inventorySelectWeaponEventExecuteUseCaseHandler;
        }

        public Task Notify(WeaponType weaponType)
        {
            _inventorySelectWeaponEventExecuteUseCaseHandler.Handle(weaponType);

            return Task.CompletedTask;
        }
    }
}
