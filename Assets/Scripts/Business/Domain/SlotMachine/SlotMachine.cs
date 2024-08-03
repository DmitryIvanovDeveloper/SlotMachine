using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.CoinSlot.UseCases;
using static SlotMachine.Business.Domain.SlotMachine.SlotMachine;

namespace SlotMachine.Business.Domain.SlotMachine
{
    public class SlotMachine : ISlotMachine, ISlotMachineInfo
    {
        public delegate void SlotChanged(SlotType slotType);
        public event SlotChanged OnSlostChanged;

        public delegate void StartGame();
        public event StartGame OnStartGame;

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
        private CoinsAddUseCase _coinsAddUseCase;

        public SlotMachine(CoinSlotTryDecreaseCoinsUseCase coinSlotTryDecreaseCoinsUseCase, CoinsAddUseCase coinsAddUseCase)
        {
            _coinSlotTryDecreaseCoinsUseCase = coinSlotTryDecreaseCoinsUseCase;
        }

        public async UniTask Play()
        {
            var coins = _coinSlotTryDecreaseCoinsUseCase.Execute();
            if (!coins.Item2)
            {
                return;
            }

            OnStartGame?.Invoke();

            var length = _values.Length;

            await UniTask.RunOnThreadPool(async () =>
            {
                await UniTask.Delay(ShapeOneShowInSeconds * 1000);
                ShapeOne = (ShapeType)_values.GetValue(_random.Next(length));
                OnSlostChanged?.Invoke(SlotType.One);

            }) ;

            await UniTask.RunOnThreadPool(async () =>
            {
                await UniTask.Delay(ShapeTwoShowInSeconds * 1000);
                ShapeTwo = (ShapeType)_values.GetValue(_random.Next(length));
                OnSlostChanged?.Invoke(SlotType.Two);
            });

            await UniTask.RunOnThreadPool(async () =>
            {
                await UniTask.Delay(ShapeThreeShowInSeconds * 1000);
                ShapeThree = (ShapeType)_values.GetValue(_random.Next(length));
                OnSlostChanged?.Invoke(SlotType.Three);
            });

            var points = GetPoints();
            if (points <= 0)
            {
                return;
            }


            _coinsAddUseCase.Execute(CoinType.Silver, points);
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