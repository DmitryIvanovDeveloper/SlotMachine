using System;
using System.Collections.Generic;

using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.CoinSlot;
using SlotMachine.Business.Domain.CoinSlot.UseCases;

namespace SlotMachine.Business.Domain.SlotMachine
{
    public class SlotMachine : ISlotMachine, ISlotMachineInfo
    {
        public delegate void ShapesChanged();
        public event ShapesChanged OnShapesChanged;

        public int NumCoinsToPlay { get; private set; } = 10;
        private CoinType _playedCoinType;

        public ShapeType ShapeOne { get; private set; }
        public ShapeType ShapeTwo { get; private set; }
        public ShapeType ShapeThree { get; private set; }

        public int ShapeOneShowInSeconds { get; private set; } = 1;
        public int ShapeTwoShowInSeconds { get; private set; } = 2;
        public int ShapeThreeShowInSeconds { get; private set; } = 3;

        private Dictionary<(ShapeType, ShapeType, ShapeType), (CoinType, int)> _pointsByShapes = new Dictionary<(ShapeType, ShapeType, ShapeType), (CoinType, int)>()
        {
            { (ShapeType.Apple, ShapeType.Apple, ShapeType.Apple), (CoinType.Silver, 100) },
            { (ShapeType.Orange, ShapeType.Orange, ShapeType.Orange), (CoinType.Silver, 300) },
            { (ShapeType.Seven, ShapeType.Seven, ShapeType.Seven), (CoinType.Golden, 100) },
        };

        private Dictionary<CoinType, int> NumCoinsToPlayByType = new Dictionary<CoinType, int>()
        {
            { CoinType.Silver, 1 },
            { CoinType.Golden, 2 },
        };

        private System.Random _random = new System.Random();
        private Array _values = Enum.GetValues(typeof(ShapeType));

        private CoinSlotTryDecreaseCoinsUseCase _coinSlotTryDecreaseCoinsUseCase;

        public SlotMachine(CoinSlotTryDecreaseCoinsUseCase coinSlotTryDecreaseCoinsUseCase)
        {
            _coinSlotTryDecreaseCoinsUseCase = coinSlotTryDecreaseCoinsUseCase;
        }

        public bool Play()
        {
            var coins = _coinSlotTryDecreaseCoinsUseCase.Execute();
            if (!coins.Item2)
            {
                return false;
            }

            var length = _values.Length;

            ShapeOne = (ShapeType)_values.GetValue(_random.Next(length));
            ShapeTwo = (ShapeType)_values.GetValue(_random.Next(length));
            ShapeThree = (ShapeType)_values.GetValue(_random.Next(length));

            OnShapesChanged?.Invoke();
            return true;
        }


        public int GetPoints()
        {
            if (!_pointsByShapes.ContainsKey((ShapeOne, ShapeTwo, ShapeThree)) ||
                !NumCoinsToPlayByType.ContainsKey(_playedCoinType))
            {
                return 0;
            }

            return _pointsByShapes[(ShapeOne, ShapeTwo, ShapeThree)].Item2 * NumCoinsToPlayByType[_playedCoinType];
        }
    }
}