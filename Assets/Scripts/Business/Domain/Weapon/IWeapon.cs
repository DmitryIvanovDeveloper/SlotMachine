using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Weapon
{
    public interface IWeapon
    {
        WeaponType WeaponType { get; }
        string Name { get; }
        double HealtInPercentage { get; }
        int Coins { get; }

        int GetDamage();
    }
}

