using System;
using System.Collections.Generic;

using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Weapon;

namespace SlotMachine.Business.Domain.Inventory
{
    public class Inventory : IInventory, IInventoryInfo
    {
        public Dictionary<WeaponType, IWeapon> Weapons { get; private set; } = new Dictionary<WeaponType, IWeapon>();
        public IWeapon SelectedWeapon { get; private set; }

        public Inventory()
        {
            CreateWeapons();
        }


        private void CreateWeapons()
        {
            var hands = new Weapon.Weapon()
            {
                Name = "Hands",
                WeaponType = WeaponType.Hands,
                Damage = 1,
                Coins = 1
            };

            var handKnuckles = new Weapon.Weapon()
            {
                Name = "Hand Knuckles",
                WeaponType = WeaponType.HandKnuckles,
                Damage = 3,
                Coins = 5,
            };

            SelectedWeapon = hands;
            Weapons[WeaponType.Hands] = hands;
            Weapons[WeaponType.HandKnuckles] = handKnuckles;
        }

        public void SelectWeapon(WeaponType weaponType)
        {
            if (!Weapons.ContainsKey(weaponType))
            {
                throw new Exception($"The weaponType {weaponType} is not suppported");
            }

            SelectedWeapon = Weapons[weaponType];
        }
    }

}

