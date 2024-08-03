using SlotMachine.Business.Domain.Player.UseCases;
using SlotMachine.Business.Domain.StageTimer;

namespace SlotMachine.Business.Domain.Police
{
    public class Police : IPoliceInfo
    {
        public delegate void DoWork();
        public event DoWork OnDoWork;

        public delegate void Arrest();
        public event Arrest OnArrested;

        private int _startInSeconds;

        private IStageTimerInfo _stageTimerInfo;
        private PlayerArrestUseCase _playerArrestUseCase;

        private System.Random _random = new System.Random();

        public Police(IStageTimerInfo stageTimerInfo, PlayerArrestUseCase playerArrestUseCase)
        {
            _stageTimerInfo = stageTimerInfo;
            _playerArrestUseCase = playerArrestUseCase;

            _stageTimerInfo.OnUpdate += NotifyIfTime;

            _startInSeconds = _random.Next(5, 15);
        }

        private void NotifyIfTime()
        {
            if (_stageTimerInfo.CurrentTime.TotalSeconds <= _startInSeconds)
            {
                OnDoWork?.Invoke();
            }

            if (_stageTimerInfo.CurrentTime.TotalSeconds <= 0)
            {
                _playerArrestUseCase.Execute();
                OnArrested?.Invoke();
            }
        }
    }
}

