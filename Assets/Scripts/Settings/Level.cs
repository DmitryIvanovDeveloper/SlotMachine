using System;
using SlotMachine.Business.Adapters;
using SlotMachine.Infrastructure.Repository;
using SlotMachine.Infrastructure.Services;
using SlotMachine.Settings.Dtos;
using UnityEngine;
using UnityEngine.UIElements;

namespace SlotMachine.Settings
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 2)]
    public class Level : ScriptableObject
    {
        [field: SerializeField]
        public string LevelId { get; private set; }

        private IDatabaseRepository  _databaseRepository= new DatabaseRepository(new DatabaseServiceFake());

        [field: SerializeField]
        public int TimeInSeconds { get; private set; }

        [RangeAttribute(1, 60)]
        [SerializeField]
        public int StartPoliceBeforeEndTimeInSeconds;

        [field: SerializeField]
        public SlotMachine SlotMachine{ get; private set; }

        [field: SerializeField]
        public Texture2D Background { get; private set; }

        [field: SerializeField]
        public Texture2D Preview { get; private set; }

        public void Save()
        {
            var guid = Guid.Parse(LevelId);
            if (guid == null)
            {
                throw new Exception($"The '{LevelId}' LevelId is not correct");
            }

            var dto = new LevelDto()
            {
                LevelId = guid,
                PreviewImage = Preview.EncodeToPNG(),
                StartPoliceBeforeEndTimeInSeconds = StartPoliceBeforeEndTimeInSeconds,
                TimeInSeconds = TimeInSeconds,
                BackgroundImage = Background.EncodeToPNG(),
                SlotMachine = SlotMachine.GetDto()
            };

            _databaseRepository.SaveLevel(dto);
        }
    }
}

