using Cysharp.Threading.Tasks;
using SlotMachine.Business.Adapters;

namespace SlotMachine.Business.Domain.Player.UseCases
{
    public class PlayerLoadDataUseCase
    {
        private IPlayer _player;
        private ILocalStorageRepository _localStorageRepository;

        public PlayerLoadDataUseCase(ILocalStorageRepository localStorageRepository, IPlayer player)
        {
            _localStorageRepository = localStorageRepository;
            _player = player;
        }

        public async UniTask Execute()
        {
            var playerData = _localStorageRepository.GetPlayer();

            await _player.Init(playerData.IsArrested, playerData.ArrestedAt);
        }
    }
}

