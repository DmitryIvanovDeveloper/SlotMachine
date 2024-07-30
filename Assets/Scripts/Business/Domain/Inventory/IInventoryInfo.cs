using SlotMachine.Business.Common;
using System.Collections.Generic;
using SlotMachine.Business.Domain.Weapon;

namespace SlotMachine.Business.Domain.Inventory
{
    public interface IInventoryInfo
    {
        Dictionary<WeaponType, IWeapon> Weapons { get; }
        IWeapon SelectedWeapon { get; }
    }
}

