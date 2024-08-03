using static SlotMachine.Business.Domain.Tokens.Tokens;

namespace SlotMachine.Business.Domain.Tokens
{
    public interface ITokensInfo
    {
        event TokensChanged OnTokensChanged;
        long Num { get; }
    }
}
