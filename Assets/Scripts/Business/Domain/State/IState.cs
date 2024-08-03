namespace SlotMachine.Business.Domain.State
{
    public interface IState
    {
        void AddDamage();
        void Repair();
        void Init(int maxHealth, int fullRepairInMinutes);
    }
}
