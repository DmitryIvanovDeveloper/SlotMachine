using SlotMachine.Infrastructure.Repository.Adapters;
using SlotMachine.Business.Adapters;

namespace SlotMachine.Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private ILocalStorageService _dataBaseService;

        public Repository(ILocalStorageService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public void SaveCoins(int numCoins)
        {
            _dataBaseService.SaveCoins($"{numCoins}");
        }
    }
}


