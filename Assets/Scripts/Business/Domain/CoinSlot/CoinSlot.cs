using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;
using UnityEngine;

namespace SlotMachine.Business.Domain.CoinSlot
{
    public class CoinSlot : ICoinSlot, ICoinSlotInfo
    {
        public int NumCoins { get; private set; }
        public CoinType CurrentCoinType { get; private set; } = CoinType.Undefined;

        public int MaxCoins { get; set; } = 5;

        private CoinsTryDecreaseUseCase _coinsTryDecreaseUseCase;
        private CoinsAddUseCase _coinsAddUseCase;

        public CoinSlot(CoinsTryDecreaseUseCase coinsTryDecreaseUseCase, CoinsAddUseCase coinsAddUseCase)
        {
            _coinsTryDecreaseUseCase = coinsTryDecreaseUseCase;
            _coinsAddUseCase = coinsAddUseCase;
        }


        public bool HasCoins(CoinType coinType)
        {
            throw new System.NotImplementedException();
        }

        public bool TryEncrease(CoinType coinType)
        {
            Debug.Log(coinType);
            if (coinType != CurrentCoinType && CurrentCoinType != CoinType.Undefined)
            {
                return false;
            }

            if (CurrentCoinType == CoinType.Undefined)
            {
                CurrentCoinType = coinType;
            }

            if (NumCoins >= MaxCoins)
            {
                return false;
            }

            var isSuccess = _coinsTryDecreaseUseCase.Execute(coinType, 1);
            if (!isSuccess)
            {
                return isSuccess;
            }

            NumCoins += 1;
            return true;
        }

        public (CoinType, int) TakeCoins()
        {
            var coins = NumCoins;
            NumCoins = 0;

            return (CurrentCoinType, coins);
        }

        public void ReturnCoins()
        {
            _coinsAddUseCase.Execute(CurrentCoinType, NumCoins);
            NumCoins = 0;
        }
    }
}

