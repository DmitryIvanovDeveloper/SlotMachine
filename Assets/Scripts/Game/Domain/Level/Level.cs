using Cysharp.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Game.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace SlotMachine.Game.Domain.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private Settings.Level _settings;

        [SerializeField]
        private Image _preview;

        private ZenjectSceneLoader _sceneLoader;

        [Inject]
        public void Construct(ZenjectSceneLoader zenjectSceneLoader)
        {
            _sceneLoader = zenjectSceneLoader;
        }

        private void Start()
        {
            _preview.sprite = _settings.Preview;
        }

        public async void Load()
        {
            var context = new Context()
            {
                TimeInSeconds = _settings.TimeInSeconds,
                StartPoliceBeforeEndTime = _settings.StartPoliceBeforeEndTime,
                SlotMachineFullRepairInMinutes = _settings.SlotMachine.FullRepairInMinutes,
                SlotMachineMaxHealth = _settings.SlotMachine.MaxHealth,
                Level = _settings
            };

            await _sceneLoader.LoadSceneAsync("GameScene", LoadSceneMode.Single, (container) =>
            {
                container.BindInstance<IGameContext>(context);
                container.BindInstance<IBusinessContext>(context);
            });
        }
    }
}

