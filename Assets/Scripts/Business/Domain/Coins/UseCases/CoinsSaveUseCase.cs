using System;
using SlotMachine.Business.Adapters;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsSaveUseCase
    {
        private IRepository _repository;
        private ICoinsInfo _coinsInfo;

        public CoinsSaveUseCase(ICoinsInfo coinsInfo, IRepository repository)
        {
            _repository = repository;
            _coinsInfo = coinsInfo;
        }

        public void Execute()
        {
            var dto = new CoinsDto()
            {
                Silver = _coinsInfo.NumCoinsByType[CoinType.Silver],
                Golden = _coinsInfo.NumCoinsByType[CoinType.Golden],
            };

            _repository.SaveCoins(dto);
        }

        private object CoinsDto()
        {
            throw new NotImplementedException();
        }
    }

}

