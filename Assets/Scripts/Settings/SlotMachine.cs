using SlotMachine.Game.Domain.State;
using System.Collections.Generic;
using UnityEngine;

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
    }
}

