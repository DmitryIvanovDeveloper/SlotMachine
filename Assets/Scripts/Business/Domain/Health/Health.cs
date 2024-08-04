using System;
using Cysharp.Threading.Tasks;
using SlotMachine.Business.Domain.Inventory;
using UnityEngine;

namespace SlotMachine.Business.Domain.Health
{
    public class Health : IHealth, IHealthInfo
    {
        public delegate void HealtChanged();
        public event HealtChanged OnHealtChanged;

        public double HealthInPercentage { get; private set; } = 100;

        public int LastDamage { get; private set; }
        private DateTime _brokenAt = DateTime.UtcNow;

        private double _maxHealth = 100;

        private int _totalHits = 0;

        private int _fullRepairInSeconds = 10;

        private IInventoryInfo _inventoryInfo;

        public Health(IInventoryInfo inventoryInfo)
        {
            _inventoryInfo = inventoryInfo;
        }

        public async UniTask StartRapair()
        {
            while (true)
            {
                await UniTask.Delay(100);
                if (_totalHits > 0)
                {
                    _totalHits--;
                }

                if (HealthInPercentage >= _maxHealth)
                {
                    continue;
                }

                HealthInPercentage += 0.7;

                OnHealtChanged?.Invoke();
            }
        }

        public bool AddDamage()
        {
            if (HealthInPercentage <= 0)
            {
                return false;
            }

            DecreaseHealth();


            if (_totalHits < _maxHealth)
            {
                _totalHits += 1;
            }
            
             OnHealtChanged?.Invoke();

            return true;
        }

        private void DecreaseHealth()
        {
            var damage = _inventoryInfo.SelectedWeapon.GetDamage();
            LastDamage = damage;
            HealthInPercentage -= (damage / _maxHealth) * 100;
        }
    }
}
