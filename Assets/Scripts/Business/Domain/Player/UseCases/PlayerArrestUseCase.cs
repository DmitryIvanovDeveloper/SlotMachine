namespace SlotMachine.Business.Domain.Player.UseCases
{
    public class PlayerArrestUseCase
    {
        private IPlayer _player;
        private PlayerSaveUseCase _playerSaveUseCase;

        public PlayerArrestUseCase(IPlayer player, PlayerSaveUseCase playerSaveUseCase)
        {
            _player = player;
            _playerSaveUseCase = playerSaveUseCase;
        }

        public void Execute()
        {
            _player.SetArrested();

            _playerSaveUseCase.Execute();
        }

    }
}

