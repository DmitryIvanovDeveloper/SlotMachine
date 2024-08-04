using Newtonsoft.Json;
using UnityEngine;

using SlotMachine.Infrastructure.Repository.Adapters;
using SlotMachine.Business.Adapters;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Infrastructure.Repository
{
    public class LocalStorageRepository : ILocalStorageRepository
    {
        private ILocalStorageService _dataBaseService;

        public LocalStorageRepository(ILocalStorageService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public PlayerDataDto LoadPlayerData()
        {
            return new PlayerDataDto()
            {
                Coins = GetCoins(),
                Tokens = GetTokens(),
                Player = GetPlayer(),
                State = GetState()
            };
        }


        public void SaveCoins(CoinsDto coins)
        {
            var data = Serialize(coins);

            _dataBaseService.SaveCoins(data);
        }

        public void SavePlayer(PlayerDto dto)
        {
            var data = Serialize(dto);

            _dataBaseService.SavePlayer(data);
        }

        public void SaveTokens(TokensDto dto)
        {
            var data = Serialize(dto);

            _dataBaseService.SaveTokens(data);
        }

        public void SaveState(StateDto dto)
        {
            var data = Serialize(dto);

            _dataBaseService.SaveState(data);
        }

        public CoinsDto GetCoins()
        {
            var data = _dataBaseService.GetCoins();

            if (string.IsNullOrEmpty(data))
            {
                Debug.LogWarning($"Coins data is null");
                return new CoinsDto();
            }

            return JsonConvert.DeserializeObject<CoinsDto>(data);
        }

        public PlayerDto GetPlayer()
        {
            var data = _dataBaseService.GetPlayer();

            if (string.IsNullOrEmpty(data))
            {
                Debug.LogWarning($"'Player' data is null");
                return new PlayerDto();
            }

            return JsonConvert.DeserializeObject<PlayerDto>(data);
        }

        public TokensDto GetTokens()
        {
            var data = _dataBaseService.GetTokens();

            if (string.IsNullOrEmpty(data))
            {
                Debug.LogWarning($"'Tokens' data is null");
                return new TokensDto();
            }

            return JsonConvert.DeserializeObject<TokensDto>(data);
        }

        public StateDto GetState()
        {
            var data = _dataBaseService.GetState();

            if (string.IsNullOrEmpty(data))
            {
                Debug.LogWarning($"'State' data is null");
                return new StateDto();
            }

            return JsonConvert.DeserializeObject<StateDto>(data);
        }

        private string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }
    }
}


