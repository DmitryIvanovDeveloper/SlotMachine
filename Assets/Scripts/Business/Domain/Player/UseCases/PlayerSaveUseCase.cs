using SlotMachine.Business.Adapters;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Domain.Player.UseCases
{
    public class PlayerSaveUseCase
    {
        private IPlayerInfo _playerInfo;
        private ILocalStorageRepository _localStorageRepository;

        public PlayerSaveUseCase(IPlayerInfo playerInfo, ILocalStorageRepository localStorageRepository)
        {
            _playerInfo = playerInfo;
            _localStorageRepository = localStorageRepository;
        }

        public void Execute()
        {
            var dto = new PlayerDto()
            {
                IsArrested = _playerInfo.IsArrested,
                ArrestedAt = _playerInfo.ArrestedAt,
            };

            _localStorageRepository.SavePlayer(dto);
        }
    }
}

