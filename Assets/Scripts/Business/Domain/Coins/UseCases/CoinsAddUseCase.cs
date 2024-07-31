using SlotMachine.Business.Common;
using UnityEngine;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsAddUseCase
    {
        private ICoins _coins;
        private CoinsSaveUseCase _coinsSaveUseCase;

        public CoinsAddUseCase(ICoins coins, CoinsSaveUseCase coinsSaveUseCase)
        {
            _coins = coins;
            _coinsSaveUseCase = coinsSaveUseCase;
        }

        public void Execute(CoinType coinType, int num)
        {
            _coins.Add(coinType, num);
            _coinsSaveUseCase.Execute();
        }
    }
}
