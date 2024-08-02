using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.StageTimer
{
    public interface IStageTimer
    {
        UniTask Start();
        void Stop();
    }
}


