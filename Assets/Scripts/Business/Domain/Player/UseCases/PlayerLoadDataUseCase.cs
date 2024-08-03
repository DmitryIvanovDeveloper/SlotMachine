using SlotMachine.Business.Adapters;

namespace SlotMachine.Business.Domain.Player.UseCases
{
    public class PlayerLoadDataUseCase
    {
        private IPlayer _player;
        private IRepository _repository;

        public PlayerLoadDataUseCase(IRepository repository, IPlayer player)
        {
            _repository = repository;
            _player = player;
        }

        public void Execute()
        {
            var playerData = _repository.GetPlayer();
            _player.Init(playerData.IsArrested);
        }
    }
}

