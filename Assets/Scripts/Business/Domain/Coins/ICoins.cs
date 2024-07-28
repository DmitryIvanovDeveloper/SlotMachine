namespace SlotMachine.Business.Domain.Coins
{
    public interface ICoins
    {
        void Encrease();
        bool TryDecrease(int num);
        void Add(int num);
    }
}


