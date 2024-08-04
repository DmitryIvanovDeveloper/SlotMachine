using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SlotMachine.Business.Adapters;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Dtos;
using SlotMachine.Game.Common;
using SlotMachine.Game.Util.Extensions;
using UI.Pagination;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace SlotMachine.Game.Domain.Levels
{
    public class Level : MonoBehaviour
    {
        [SerializeField]
        private GameObject _levelPrefab;
        [SerializeField]
        private PagedRect _pagedRect;

        private List<LevelDto> _levels;

        private ZenjectSceneLoader _sceneLoader;
        private IDatabaseRepository _databaseRepository;

        [Inject]
        public void Construct(ZenjectSceneLoader zenjectSceneLoader, IDatabaseRepository databaseRepository)
        {
            _sceneLoader = zenjectSceneLoader;
            _databaseRepository = databaseRepository;
        }

        private async void Start()
        {
            _levels = await _databaseRepository.GetLevels();

            foreach(var level in _levels)
            {
                InstantiateLevel(level);
            }
        }

        private void InstantiateLevel(LevelDto level)
        {
            var levelgameObject = Instantiate(_levelPrefab);
            var page = levelgameObject.GetComponentOrThrow<Page>();

            var buttonGameObject = levelgameObject.FindChildOrThrow("Button");

            var button = buttonGameObject.GetComponentOrThrow<Button>();

            button.onClick.AddListener(async delegate
            {
                await Load(level);
            });

            var rawImage = buttonGameObject
                .FindChildOrThrow("Background")
                .GetComponentOrThrow<Image>();
            ;

            rawImage.sprite = ConvertUrlToSprite(level.PreviewImage);

            _pagedRect.AddPage(page);
        }

        private Sprite ConvertUrlToSprite(byte[] imageBytes)
        {
            var texture = new Texture2D(2, 2, TextureFormat.BGRA32, false);
            texture.LoadImage(imageBytes);
            texture.Apply();
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        }

        private async UniTask Load(LevelDto level)
        {
            var context = new Context()
            {
                TimeInSeconds = level.TimeInSeconds,
                StartPoliceBeforeEndTime = level.StartPoliceBeforeEndTimeInSeconds,
                SlotMachineFullRepairInMinutes = level.SlotMachine.FullRepairInMinutes,
                SlotMachineMaxHealth = level.SlotMachine.MaxHealth,
                Level = level
            };

            await _sceneLoader.LoadSceneAsync("GameScene", LoadSceneMode.Single, (container) =>
            {
                container.BindInstance<IGameContext>(context);
                container.BindInstance<IBusinessContext>(context);
            });
        }
    }
}

