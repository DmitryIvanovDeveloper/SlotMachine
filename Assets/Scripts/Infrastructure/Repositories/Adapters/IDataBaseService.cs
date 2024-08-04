using Cysharp.Threading.Tasks;
using SlotMachine.Infrastructure.Repository.Adapters.Responses;
using System.Collections.Generic;

namespace SlotMachine.Infrastructure.Repository.Adapters
{
    public interface IDatabaseService
    {
        void SaveCoins(int numCoins);
        UniTask<IResponse<List<ILevelsResponse>>> GetLevels();
        UniTask PostLevel(string data);
    }
}

