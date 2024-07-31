using System;
using SlotMachine.Business.Common;
using UnityEngine;

namespace SlotMachine.Game.Domain.Inventory
{
    [Serializable]
    public class InventoryImages
    {
        [field: SerializeField]
        public WeaponType WeaponType { get; set; }

        [field: SerializeField]
        public Sprite Image { get; set; }
    }

}

