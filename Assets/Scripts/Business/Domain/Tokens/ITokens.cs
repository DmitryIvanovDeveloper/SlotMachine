namespace SlotMachine.Business.Domain.Tokens
{
    public interface ITokens
    {
        void Add(int num);
        void Encrease();
        void Init(long num);
    }
}
