using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsTryDecreaseUseCase
    {
        private ICoins _coins;
        private CoinsSaveUseCase _coinsSaveUseCase;

        public CoinsTryDecreaseUseCase(ICoins coins, CoinsSaveUseCase coinsSaveUseCase)
        {
            _coins = coins;
            _coinsSaveUseCase = coinsSaveUseCase;
        }

        public bool Execute(CoinType coinType, int num)
        {
            var isSuccess = _coins.TryDecrease(coinType, num);
            if (!isSuccess)
            {
                return isSuccess;
            }

            _coinsSaveUseCase.Execute();

            return isSuccess;
        }
    }
}
