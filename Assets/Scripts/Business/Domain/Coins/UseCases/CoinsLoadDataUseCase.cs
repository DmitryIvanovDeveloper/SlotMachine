using SlotMachine.Business.Adapters;
using UnityEngine;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsLoadDataUseCase
    {
        private ILocalStorageRepository _localStorageRepository;
        private ICoins _coins;

        public CoinsLoadDataUseCase(ICoins coins, ILocalStorageRepository localStorageRepository)
        {
            _localStorageRepository = localStorageRepository;
            _coins = coins;
        }

        public void Execute()
        {
            var dto = _localStorageRepository.GetCoins();

            _coins.Init(dto.Silver,  dto.Golden);
        }
    }
}

