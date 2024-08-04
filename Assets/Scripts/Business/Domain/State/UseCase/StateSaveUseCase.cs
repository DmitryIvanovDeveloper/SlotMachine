using SlotMachine.Business.Adapters;
using SlotMachine.Business.Domain.Dtos;

namespace SlotMachine.Business.Domain.State.UseCase
{
    public class StateSaveUseCase
    {
        private ILocalStorageRepository _localStorageRepository;
        private IStateInfo _stateInfo;

        public StateSaveUseCase(IStateInfo stateInfo, ILocalStorageRepository localStorageRepository)
        {
            _localStorageRepository = localStorageRepository;
            _stateInfo = stateInfo;
        }

        public void Execute()
        {
            var dto = new StateDto()
            {
                StateType = _stateInfo.CurrentStateType,
                ChangedStateAt = _stateInfo.ChangedStateAt,
            };

            _localStorageRepository.SaveState(dto);
        }
    }
}

