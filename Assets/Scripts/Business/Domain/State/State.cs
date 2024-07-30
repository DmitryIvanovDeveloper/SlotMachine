using System;

using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.Inventory;

namespace SlotMachine.Business.Domain.State
{
    public class State : IState, IStateInfo
    {
        public StateType CurrentStateType { get; private set; } = StateType.New;
        public double HealthInPercentage { get; private set; } = 100;

        public int LastDamage { get; private set; }
        private DateTime _brokenAt = DateTime.UtcNow;

        private double _maxHealth = 100;

        private int _totalHits = 0;

        private int _currentHits = 0;
        private int _numHitsToGetCoin = 10;

        private int _fullRepairInMinutes = 2;

        private Random _random = new Random();


        private CoinsAddUseCase _coinsAddUseCase;
        private IInventoryInfo _inventoryInfo;


        public State(IInventoryInfo inventoryInfo, CoinsAddUseCase coinsAddUseCase)
        {
            _coinsAddUseCase = coinsAddUseCase;
            _inventoryInfo = inventoryInfo;
        }

        public void AddDamage()
        {
            DecreaseHealth();

            if (_totalHits < _maxHealth)
            {
                _totalHits += 1;
                _currentHits += 1;
            }

            if (_totalHits == (_maxHealth / 2))
            {
                CurrentStateType = StateType.HalfBroken;
            }

            if (_totalHits == (_maxHealth - (_maxHealth / 4)))
            {
                CurrentStateType = StateType.QuatroBroken;
            }

            if (HealthInPercentage <= 0)
            {
                CurrentStateType = StateType.Broken;
                _brokenAt = DateTime.UtcNow;
            }

            if (_random.Next(1, 10) == 2)
            {
                _coinsAddUseCase.Execute(CoinType.Silver, _random.Next(1, _inventoryInfo.SelectedWeapon.Coins));

                _currentHits = 0;
            }
        }

        private void DecreaseHealth()
        {
            var damage = _inventoryInfo.SelectedWeapon.GetDamage();
            LastDamage = damage;
            HealthInPercentage -= (damage / _maxHealth) * 100;
        }

        public void Repair()
        {
            var spentTime = DateTime.UtcNow - _brokenAt;

            var staminaPercentageLastFeedAt = spentTime.TotalMinutes / _fullRepairInMinutes * 100;

            //var actualStaminaPercentage = staminaPercentage + staminaPercentageLastFeedAt;

            HealthInPercentage = staminaPercentageLastFeedAt > 100
                ? 100
                : staminaPercentageLastFeedAt //actualStaminaPercentage
            ;

            if (HealthInPercentage >= 100)
            {
                CurrentStateType = StateType.New;
                _currentHits = 0;
                _totalHits = 0;
            }
        }
    }
}

