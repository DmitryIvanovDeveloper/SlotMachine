using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Business.Domain.State;

namespace SlotMachine.Business.Domain.Bonus
{
    public class Bonus : IBonusInfo
    {
        public delegate void AddBonus(CoinType coinType, int num);
        public event AddBonus OnAddBonus;

        private IStateInfo _stateInfo;
        private CoinsAddUseCase _coinsAddUseCase;

        public Bonus(IStateInfo stateInfo, CoinsAddUseCase coinsAddUseCase)
        {
            _stateInfo = stateInfo;

            _coinsAddUseCase = coinsAddUseCase;
            _stateInfo.OnStateChanged += Add;
        }

        private void Add()
        {
            if (_stateInfo.CurrentStateType != StateType.Broken)
            {
                return;
            }

            _coinsAddUseCase.Execute(CoinType.Silver, 30);
            OnAddBonus?.Invoke(CoinType.Silver, 30);
        }
    }
}
