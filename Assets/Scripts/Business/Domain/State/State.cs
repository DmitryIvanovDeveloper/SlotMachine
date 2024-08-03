using System;

using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.Inventory;
using SlotMachine.Business.Domain.StageTimer;

namespace SlotMachine.Business.Domain.State
{
    public class State : IState, IStateInfo
    {
        public delegate void StateChanged();
        public event StateChanged OnStateChanged;

        public StateType CurrentStateType { get; private set; } = StateType.New;
        public double HealthInPercentage { get; private set; } = 100;

        private DateTime _brokenAt = DateTime.UtcNow;

        private double _maxHealth = 300;

        private int _totalHits = 0;

        private int _fullRepairInMinutes = 2;

        System.Random _random = new System.Random();


        private CoinsAddUseCase _coinsAddUseCase;
        private IInventoryInfo _inventoryInfo;
        private StageTimerStopUseCase _stageTimerStopUseCase;

        public State(IInventoryInfo inventoryInfo,
            CoinsAddUseCase coinsAddUseCase,
            StageTimerStopUseCase stageTimerStopUseCase
        )
        {
            _coinsAddUseCase = coinsAddUseCase;
            _inventoryInfo = inventoryInfo;
            _stageTimerStopUseCase = stageTimerStopUseCase;
        }

        public void Init(int maxHealth, int fullRepairInMinutes)
        {
            _maxHealth = maxHealth;
            _fullRepairInMinutes = fullRepairInMinutes;
        }

        public void AddDamage()
        {
            DecreaseHealth();

            if (_totalHits < _maxHealth)
            {
                _totalHits += 1;
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
                _stageTimerStopUseCase.Execute();
            }

            if (_random.Next(1, 30) == 2)
            {
                _coinsAddUseCase.Execute(CoinType.Silver, _random.Next(1, _inventoryInfo.SelectedWeapon.Coins));
            }

            OnStateChanged?.Invoke();

        }

        private void DecreaseHealth()
        {
            var damage = _inventoryInfo.SelectedWeapon.GetDamage();
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
                _totalHits = 0;
            }
        }
    }
}

