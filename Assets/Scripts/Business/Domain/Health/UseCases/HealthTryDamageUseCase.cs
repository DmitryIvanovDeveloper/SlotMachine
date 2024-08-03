using Cysharp.Threading.Tasks;

namespace SlotMachine.Business.Domain.Health.UseCases
{
    public class HealthTryDamageUseCase
    {
        private IHealth _health;

        public HealthTryDamageUseCase(IHealth health)
        {
            _health = health;
        }

        public bool Execute()
        {
            return _health.AddDamage();
        }
    }
}


