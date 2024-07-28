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

        public void Execute()
        {
            _coins.Encrease();
            _coinsSaveUseCase.Execute();
        }
    }
}
