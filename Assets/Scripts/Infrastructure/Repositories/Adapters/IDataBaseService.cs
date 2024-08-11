using Cysharp.Threading.Tasks;
using System.Collections.Generic;

using SlotMachine.Infrastructure.Repository.Adapters.Responses;

namespace SlotMachine.Infrastructure.Repository.Adapters
{
    public interface IDatabaseService
    {
        void SaveCoins(int numCoins);
        UniTask<IResponse<List<ILevelsResponse>>> GetLevels();
        UniTask PostLevel(string data);
        UniTask UpdateTokens(string accessToken, string jsonData);
    }
}

