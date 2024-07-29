using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsEncreaseUseCase
    {
        private ICoins _coins;
        private CoinsSaveUseCase _coinsSaveUseCase;

        public CoinsEncreaseUseCase(ICoins coins, CoinsSaveUseCase coinsSaveUseCase)
        {
            _coins = coins;
            _coinsSaveUseCase = coinsSaveUseCase;
        }

        public void Execute(CoinType coinType)
        {
            _coins.Encrease(coinType);
            _coinsSaveUseCase.Execute();
        }
    }
}
