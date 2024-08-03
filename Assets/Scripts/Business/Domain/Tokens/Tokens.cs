namespace SlotMachine.Business.Domain.Tokens
{
    public class Tokens : ITokens, ITokensInfo
    {
        public delegate void TokensChanged();
        public event TokensChanged OnTokensChanged;

        public long Num { get; private set; }

        public void Init(long num)
        {
            Num = num;
        }

        public void Add(int num)
        {
            Num += num;
            OnTokensChanged?.Invoke();
        }

        public void Encrease()
        {
            Num += 1;
            OnTokensChanged?.Invoke();
        }
    }
}


