using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.StageTimer
{
    public interface IStageTimer
    {
        void Init(int maxTimeInSeconds);
        UniTask Start();
        void Stop();
    }
}


