using Cysharp.Threading.Tasks;
using SlotMachine.Business.Domain.Health.UseCases;

namespace SlotMachine.Business.Common.UseCases
{
    public class StageStartUseCase
    {
        private HealthStartRepairUseCase _healthStartRepairUseCase;

        public StageStartUseCase(
            HealthStartRepairUseCase healthStartRepairUseCase
        )
        {
            _healthStartRepairUseCase = healthStartRepairUseCase;
        }

        public async UniTask Execute()
        {
            await _healthStartRepairUseCase.Execute();
        }
    }
}
