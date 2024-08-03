using SlotMachine.Business.Adapters;
using UnityEngine;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsLoadDataUseCase
    {
        private IRepository _repository;
        private ICoins _coins;

        public CoinsLoadDataUseCase(ICoins coins, IRepository repository)
        {
            _repository = repository;
            _coins = coins;
        }

        public void Execute()
        {
            var dto = _repository.GetCoins();

            _coins.Init(dto.Silver,  dto.Golden);
        }
    }
}

