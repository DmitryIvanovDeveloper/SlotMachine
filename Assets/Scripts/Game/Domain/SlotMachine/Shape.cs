using System;
using UnityEngine;

using SlotMachine.Business.Common;

namespace SlotMachine.Game.Domain.SlotMachine
{
    [Serializable]
    public class Shape
    {
        [field: SerializeField]
        public ShapeType ShapeType { get; private set; }

        [field: SerializeField]
        public Sprite Image { get; private set; }
    }
}
