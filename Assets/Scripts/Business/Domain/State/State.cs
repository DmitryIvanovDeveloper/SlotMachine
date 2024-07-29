using UnityEngine;

using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;
using System;

namespace SlotMachine.Business.Domain.State
{
    public class State : IState, IStateInfo
    {
        public StateType CurrentStateType { get; private set; } = StateType.New;
        
        private int _maxHits = 100;

        private int _totalHits = 0;

        private int _currentHits = 0;
        private int _numHitsToGetCoin = 10;

        private int _fullRepairInMinutes = 2;

        public double CurrentRepairInPercentage { get; private set; }

        private CoinsAddUseCase _coinsAddUseCase;

        private DateTime _brokenAt = DateTime.UtcNow;

        public State(CoinsAddUseCase coinsAddUseCase)
        {
            _coinsAddUseCase = coinsAddUseCase;
        }

        public void AddDamage()
        {
            if (_totalHits < _maxHits)
            {
                _totalHits += 1;
                _currentHits += 1;
            }

            if (_totalHits == (_maxHits / 2))
            {
                CurrentStateType = StateType.HalfBroken;
            }

            if (_totalHits == (_maxHits - (_maxHits / 4)))
            {
                CurrentStateType = StateType.QuatroBroken;
            }

            if (_totalHits == _maxHits)
            {
                CurrentStateType = StateType.Broken;
                _brokenAt = DateTime.UtcNow;
            }

            if (_currentHits >= _numHitsToGetCoin)
            {
                _coinsAddUseCase.Execute(CoinType.Silver, 1);

                _currentHits = 0;
            }
        }

        public void Repair()
        {
            var spentTime = DateTime.UtcNow - _brokenAt;

            var staminaPercentageLastFeedAt = spentTime.TotalMinutes / _fullRepairInMinutes * 100;

            //var actualStaminaPercentage = staminaPercentage + staminaPercentageLastFeedAt;

            CurrentRepairInPercentage = staminaPercentageLastFeedAt > 100
                ? 100
                : staminaPercentageLastFeedAt //actualStaminaPercentage
            ;

            if (CurrentRepairInPercentage >= 100)
            {
                CurrentStateType = StateType.New;
                _currentHits = 0;
                _totalHits = 0;
            }
        }
    }
}

