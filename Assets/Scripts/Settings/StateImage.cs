using System;
using SlotMachine.Business.Common;
using UnityEngine;

namespace SlotMachine.Settings
{
    [Serializable]
    public class StateImage
    {
        [field: SerializeField]
        public StateType StateType { get; set; }

        [field: SerializeField]
        public Texture2D Image { get; set; }
    }
}
