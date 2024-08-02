using static SlotMachine.Business.Domain.Police.Police;

namespace SlotMachine.Business.Domain.Police
{
    public interface IPoliceInfo
    {
        event DoWork OnDoWork;
        event Arrest OnArrested;
    }
}

