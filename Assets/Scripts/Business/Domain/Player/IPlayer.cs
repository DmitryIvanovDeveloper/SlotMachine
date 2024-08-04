using System;
using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.Player
{
    public interface IPlayer
    {
        UniTask Init(bool isArrested, DateTime arrestedAt);
        void SetArrested();
    }
}

