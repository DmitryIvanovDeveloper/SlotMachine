using System;
using SlotMachine.Business.Adapters;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsSaveUseCase
    {
        private ILocalStorageRepository _localStorageRepository;
        private ICoinsInfo _coinsInfo;

        public CoinsSaveUseCase(ICoinsInfo coinsInfo, ILocalStorageRepository localStorageRepository)
        {
            _localStorageRepository = localStorageRepository;
            _coinsInfo = coinsInfo;
        }

        public void Execute()
        {
            var dto = new CoinsDto()
            {
                Silver = _coinsInfo.NumCoinsByType[CoinType.Silver],
                Golden = _coinsInfo.NumCoinsByType[CoinType.Golden],
            };

            _localStorageRepository.SaveCoins(dto);
        }

        private object CoinsDto()
        {
            throw new NotImplementedException();
        }
    }

}

