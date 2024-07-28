namespace SlotMachine.Business.Domain.Coins
{
    public class Coins : ICoins, ICoinsInfo
    {
        public int NumCoinsOnTap { get; private set; } = 1;

        public int Num { get; private set; }

        public void Encrease()
        {
            Num += NumCoinsOnTap;
        }

        public void Add(int num)
        {
            Num += num;
        }

        public bool TryDecrease(int num)
        {
            if (Num - num < 0)
            {
                return false;
            }


            Num -= num;

            return true;
        }
    }
}
