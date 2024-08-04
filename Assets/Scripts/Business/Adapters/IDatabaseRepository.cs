using Cysharp.Threading.Tasks;
using SlotMachine.Business.Domain.Dtos;
using System.Collections.Generic;

namespace SlotMachine.Business.Adapters
{
    public interface IDatabaseRepository
    {
        UniTask<List<LevelDto>> GetLevels();
        void SaveLevel(Settings.Dtos.LevelDto dto);
    }
}

