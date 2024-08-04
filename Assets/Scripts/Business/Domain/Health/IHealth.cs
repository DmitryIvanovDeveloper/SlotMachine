using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.Health
{
    public interface IHealth
    {
        bool AddDamage();
        UniTask StartRapair();
    }
}


