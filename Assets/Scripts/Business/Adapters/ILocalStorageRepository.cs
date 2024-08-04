using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Adapters
{
    public interface ILocalStorageRepository
    {
        void SaveCoins(CoinsDto coins);
        void SavePlayer(PlayerDto dto);
        void SaveTokens(TokensDto dto);

        CoinsDto GetCoins();
        PlayerDto GetPlayer();
        TokensDto GetTokens();

        PlayerDataDto LoadPlayerData();
        void SaveState(StateDto dto);
    }
}

