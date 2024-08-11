using UnityEngine;
using Zenject;

using SlotMachine.Infrastructure.Repository.Adapters;
using SlotMachine.Business.Adapters;

namespace SlotMachine.Game.Common
{
    public class DatabaseSaveDelay : MonoBehaviour
    {
        private ILocalStorageService _localStoreService;
        private IDatabaseRepository _dataBaseRepository;
        private bool _isSaved = true;

        private float _timelaps;

        [Inject]
        public void Construct(ILocalStorageService localStoreService, IDatabaseRepository dataBaseRepository)
        {
            _localStoreService = localStoreService;

            _dataBaseRepository = dataBaseRepository;

            _localStoreService.OnTokensUpdated += () =>
            {
                _isSaved = false;
                enabled = true;

                return 0;
            };
        }

        private void Start()
        {
            enabled = false;
        }

        private async void Update()
        {
            if (_isSaved)
            {
                return;
            }

            _timelaps += Time.deltaTime;

            if (_timelaps < 1)
            {
                return;
            }
            _isSaved = true;
            _timelaps = 0;

            await _dataBaseRepository.UpdateTokens();
            enabled = false;
        }
    }
}

