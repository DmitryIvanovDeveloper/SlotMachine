using Cysharp.Threading.Tasks;
using System;

namespace SlotMachine.Business.Domain.State
{
    public interface IState
    {
        void AddDamage();
        UniTask Repair();
        UniTask Init(int maxHealth, int fullRepairInMinutes, DateTime brokenAt);
    }
}
