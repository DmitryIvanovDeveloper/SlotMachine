using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Inventory
{
    public class InventorySelectWeaponUseCase
    {
        private IInventory _inventory;

        public InventorySelectWeaponUseCase(IInventory inventory)
        {
            _inventory = inventory;
        }

        public void Execute(WeaponType weaponType) 
        {
            _inventory.SelectWeapon(weaponType);
        }
    }
}
