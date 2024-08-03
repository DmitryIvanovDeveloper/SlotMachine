using UnityEngine;
using Zenject;

using SlotMachine.Business.Domain.Common.UseCases;
using UnityEngine.UI;

namespace SlotMachine.Game.Common
{
    public class DataLoader : MonoBehaviour
    {
        [SerializeField]
        private Image _background;

        private LoadDataUseCase _loadDataUseCase;
        private IGameContext _gameContext;
        [Inject]
        public void Construct(LoadDataUseCase loadDataUseCase, IGameContext gameContext)
        {
            _loadDataUseCase = loadDataUseCase;
            _gameContext = gameContext;

        }
        // Use this for initialization
        void Awake()
        {
            _background.sprite = _gameContext.Level.Background;

            _loadDataUseCase.Execute();
        }
    }
}


