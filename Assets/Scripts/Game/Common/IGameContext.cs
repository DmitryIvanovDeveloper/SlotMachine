using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Game.Common
{
    public interface IGameContext
    {
        LevelDto Level { get; }
    }
}
