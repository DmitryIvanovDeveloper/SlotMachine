namespace SlotMachine.Business.Domain.Player
{
    public class Player : IPlayer, IPlayerInfo
    {
        public bool IsArrested { get; private set; }

        public void Init(bool isArrested)
        {
            IsArrested = isArrested;
        }

        public void SetArrested()
        {
            IsArrested = true;
        }
    }
}

