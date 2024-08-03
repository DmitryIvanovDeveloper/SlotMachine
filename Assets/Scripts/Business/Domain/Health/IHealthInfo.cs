using static SlotMachine.Business.Domain.Health.Health;

namespace SlotMachine.Business.Domain.Health
{
    public interface IHealthInfo
    {
        event HealtChanged OnHealtChanged;
        double HealthInPercentage { get; }
    }
}


