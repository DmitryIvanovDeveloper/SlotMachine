using SlotMachine.Business.Adapters;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Domain.Player.UseCases
{
    public class PlayerSaveUseCase
    {
        private IPlayerInfo _playerInfo;
        private IRepository _repository;

        public PlayerSaveUseCase(IPlayerInfo playerInfo, IRepository repository)
        {
            _playerInfo = playerInfo;
            _repository = repository;
        }

        public void Execute()
        {
            var dto = new PlayerDto()
            {
                IsArrested = _playerInfo.IsArrested
            };

            _repository.SavePlayer(dto);
        }
    }
}

