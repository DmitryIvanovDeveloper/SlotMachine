using UnityEngine;

namespace SlotMachine.Settings
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 2)]
    public class Level : ScriptableObject
    {
        [field: SerializeField]
        public int TimeInSeconds { get; private set; }

        [RangeAttribute(1, 60)]
        [SerializeField]
        public int StartPoliceBeforeEndTime;

        [field: SerializeField]
        public SlotMachine SlotMachine{ get; private set; }

        [field: SerializeField]
        public Sprite Background { get; private set; }

        [field: SerializeField]
        public Sprite Preview { get; private set; }
    }
}

