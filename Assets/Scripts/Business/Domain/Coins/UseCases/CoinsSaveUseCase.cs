using SlotMachine.Business.Adapters;

namespace SlotMachine.Business.Domain.Coins.UseCases
{
    public class CoinsSaveUseCase
    {
        private IRepository _dataBaseRepository;
        private ICoinsInfo _coinsInfo;

        public CoinsSaveUseCase(ICoinsInfo coinsInfo, IRepository dataBaseRepository)
        {
            _dataBaseRepository = dataBaseRepository;
            _coinsInfo = coinsInfo;
        }

        public void Execute()
        {
            //_dataBaseRepository.SaveCoins(_coinsInfo.Num);
        }
    }

}

