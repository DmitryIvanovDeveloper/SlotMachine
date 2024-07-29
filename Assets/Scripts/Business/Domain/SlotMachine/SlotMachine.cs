using System;
using System.Collections.Generic;

using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins;
using SlotMachine.Business.Domain.CoinSlot;

namespace SlotMachine.Business.Domain.SlotMachine
{
    public class SlotMachine : ISlotMachine, ISlotMachineInfo
    {
        public int NumCoinsToPlay { get; private set; } = 10;

        public ShapeType ShapeOne { get; private set; }
        public ShapeType ShapeTwo { get; private set; }
        public ShapeType ShapeThree { get; private set; }

        public int ShapeOneShowInSeconds { get; private set; } = 1;
        public int ShapeTwoShowInSeconds { get; private set; } = 2;
        public int ShapeThreeShowInSeconds { get; private set; } = 3;

        private Dictionary<(ShapeType, ShapeType, ShapeType), int> _pointsByShapes = new Dictionary<(ShapeType, ShapeType, ShapeType), int>()
        {
            { (ShapeType.Apple, ShapeType.Apple, ShapeType.Apple), 1000 },
            { (ShapeType.Orange, ShapeType.Orange, ShapeType.Orange), 3000 },
            { (ShapeType.Seven, ShapeType.Seven, ShapeType.Seven), 10000 },
        };

        private Dictionary<CoinType, int> NumCoinsToPlayByType = new Dictionary<CoinType, int>()
        {
            { CoinType.Silver, 1 },
            { CoinType.Golden, 1 },
        };

        private System.Random _random = new System.Random();
        private Array _values = Enum.GetValues(typeof(ShapeType));

        private ICoinSlot _coinSlot;

        public SlotMachine(ICoinSlot coinSlot)
        {
            _coinSlot = coinSlot;
        }

        public bool Play()
        {
            var isSuccess = _coinSlot.TryDecreaseAll();
            if (!isSuccess)
            {
                return false;
            }

            var length = _values.Length;

            ShapeOne = (ShapeType)_values.GetValue(_random.Next(length));
            ShapeTwo = (ShapeType)_values.GetValue(_random.Next(length));
            ShapeThree = (ShapeType)_values.GetValue(_random.Next(length));

            return true;
        }

        public int GetPoints()
        {
            if (!_pointsByShapes.ContainsKey((ShapeOne, ShapeTwo, ShapeThree)))
            {
                return 0;
            }

            return _pointsByShapes[(ShapeOne, ShapeTwo, ShapeThree)];
        }
    }
}