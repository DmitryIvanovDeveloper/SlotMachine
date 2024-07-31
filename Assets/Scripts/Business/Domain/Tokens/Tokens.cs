namespace SlotMachine.Business.Domain.Tokens
{
    public class Tokens : ITokens, ITokensInfo
    {
        public long Num { get; private set; }

        public void Add(int num)
        {
            Num += num;
        }
    }
}


