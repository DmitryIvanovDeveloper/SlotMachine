
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.Inventory;
using SlotMachine.Business.Domain.State;

namespace SlotMachine.Business.Domain.Tokens.UseCase
{
    public class TokensAddUseCase
    {
        private ITokens _tokens;
        private IStateInfo _stateInfo;
        private IInventoryInfo _inventoryInfo;

        public TokensAddUseCase(ITokens tokens, IStateInfo stateInfo, IInventoryInfo inventoryInfo)
        {
            _tokens = tokens;
            _stateInfo = stateInfo;
            _inventoryInfo = inventoryInfo;
        }

        public void Execute()
        {
            if (_stateInfo.CurrentStateType == StateType.Broken)
            {
                return;
            }

            _tokens.Add(_inventoryInfo.SelectedWeapon.GetDamage());
        }
    }
}


