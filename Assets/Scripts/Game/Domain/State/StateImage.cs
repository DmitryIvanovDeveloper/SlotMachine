using System;
using SlotMachine.Business.Common;
using UnityEngine;

namespace SlotMachine.Game.Domain.State
{
    [Serializable]
    public class StateImage
    {
        [field: SerializeField]
        public StateType StateType { get; set; }

        [field: SerializeField]
        public Sprite Image { get; set; }
    }
}
