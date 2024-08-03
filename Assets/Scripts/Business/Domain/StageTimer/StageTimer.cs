using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace SlotMachine.Business.Domain.StageTimer
{
    public class StageTimer : IStageTimer, IStageTimerInfo
    {
        public delegate void Update();
        public event Update OnUpdate;

        public int MaxTimeInSeconds { get; private set; } = 60;
        public TimeSpan CurrentTime { get; private set; }
        private DateTime _startTime;

        public double LeftTimeInSeconds { get; private set; }

        private bool _isStarted;

        public void Init(int maxTimeInSeconds)
        {
            MaxTimeInSeconds = maxTimeInSeconds;
        }

        public async UniTask Start()
        {
            _startTime = DateTime.UtcNow;
            CurrentTime = TimeSpan.FromSeconds(MaxTimeInSeconds);

            _isStarted = true;

            await DoWork();
        }

        public async UniTask DoWork()
        {
            while (CurrentTime.TotalSeconds > 0 && _isStarted)
            {
                await UniTask.Delay(1000);
                var spentTime = DateTime.UtcNow - _startTime;

                CurrentTime = TimeSpan.FromSeconds(MaxTimeInSeconds) - spentTime;
                OnUpdate?.Invoke();
            }
           
        }

        public void Stop()
        {
            _isStarted = false;
        }


        public string GetLeftTime()
        {
            var spentTime = DateTime.UtcNow - _startTime;

            var currentTime = TimeSpan.FromSeconds(MaxTimeInSeconds) - spentTime;
            if (currentTime.TotalSeconds <= 0)
            {
                return string.Format("{0:D2}: {1:D2}", 0, 0);
            }

            return  string.Format("{0:D2}: {1:D2}", currentTime.Minutes, currentTime.Seconds);
        }
    }

}

