namespace SlotMachine.Infrastructure.Repository.Adapters
{
    public interface ILocalStorageService
    {
        void ResetProgress();
        void SaveCoins(string coins);
    }
}


