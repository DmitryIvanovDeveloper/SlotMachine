using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Weapon
{
    public class Weapon : IWeapon
    {
        public WeaponType WeaponType { get; set; }
        public string Name { get; set; }

        public double HealtInPercentage { get; private set; } = 100;

        public int Damage { get; set; }

        public int Coins { get; set; }

        public int GetDamage()
        {
            return Damage;
        }
    }

}

