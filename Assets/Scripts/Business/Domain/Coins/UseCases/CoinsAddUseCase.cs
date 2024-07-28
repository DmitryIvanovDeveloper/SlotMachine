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

        public void Execute(int num)
        {
            _coins.Add(num);
            _coinsSaveUseCase.Execute();
        }
    }
}
