using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.Health.UseCases
{
    public class HealthStartRepairUseCase
    {
        private IHealth _health;

        public HealthStartRepairUseCase(IHealth health)
        {
            _health = health;
        }

        public async UniTask Execute()
        {
            await _health.StartRapair();
        }
    }
}


