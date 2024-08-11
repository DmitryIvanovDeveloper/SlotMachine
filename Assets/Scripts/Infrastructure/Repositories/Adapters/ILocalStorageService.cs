using static SlotMachine.Infrastructure.Services.LocalStorageService;

namespace SlotMachine.Infrastructure.Repository.Adapters
{
    public interface ILocalStorageService
    {
        event TokensUpdate OnTokensUpdated;

        void ResetProgress();
        void SaveCoins(string coins);
        void SavePlayer(string data);
        void SaveTokens(string data);
        void SaveState(string data);

        string GetCoins();
        string GetPlayer();
        string GetTokens();
        string GetState();

    }
}


