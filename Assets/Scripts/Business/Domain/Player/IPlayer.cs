namespace SlotMachine.Business.Domain.Player
{
    public interface IPlayer
    {
        void Init(bool isArrested);
        void SetArrested();
    }
}

