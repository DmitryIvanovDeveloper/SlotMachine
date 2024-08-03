using SlotMachine.Infrastructure.Utils;

namespace SlotMachine.Infrastructure.Repository.Adapters
{
    public interface ILocalStorageService
    {
        void ResetProgress();
        void SaveCoins(string coins);
        void SavePlayer(string data);
        void SaveTokens(string data);

        string GetCoins();
        string GetPlayer();
        string GetTokens();
    }
}


