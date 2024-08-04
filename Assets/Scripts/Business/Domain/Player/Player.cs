using System;
using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.Player
{
    public class Player : IPlayer, IPlayerInfo
    {
        public delegate void ArrestTimerUpdate();
        public event ArrestTimerUpdate OnArrestTimerUpdate;

        public bool IsArrested { get; private set; }
        public DateTime ArrestedAt { get; private set; }
        private int AresstTimeInHours = 8;

        public async UniTask Init(bool isArrested, DateTime arrestedAt)
        {
            IsArrested = isArrested;
            ArrestedAt = arrestedAt;

            await TryLiftArrest();
        }

        public void SetArrested()
        {
            IsArrested = true;
            ArrestedAt = DateTime.UtcNow;
        }

        private async UniTask TryLiftArrest()
        {
            while (IsArrested)
            {
                await UniTask.Delay(1000);

                var spentTime = DateTime.UtcNow - ArrestedAt;

                var isLiftArrest = TimeSpan.FromMinutes(AresstTimeInHours * 60) - spentTime;

                if (isLiftArrest.TotalSeconds <= 0)
                {
                    IsArrested = false;
                }

                OnArrestTimerUpdate?.Invoke();
            }
        }

        public string GetLiftArrestTime()
        {
            var spentTime = DateTime.UtcNow - ArrestedAt;

            var currentTime = TimeSpan.FromMinutes(AresstTimeInHours * 60) - spentTime;
            if (currentTime.TotalSeconds <= 0)
            {
                return string.Format("{0:D2}: {1:D2}: {2:D2}", 0, 0, 0);
            }

            return string.Format("{0:D2}: {1:D2}: {2:D2}", currentTime.Hours,  currentTime.Minutes, currentTime.Seconds);
        }
    }
}

