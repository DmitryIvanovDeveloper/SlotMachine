using SlotMachine.Business.Common;

namespace SlotMachine.Business.Domain.Police.UseCases
{
    public class PoliceLoadDataUseCase
    {
        private IPolice _police;
        private IBusinessContext _businessContext;

        public PoliceLoadDataUseCase(IPolice police, IBusinessContext businessContext)
        {
            _police = police;
            _businessContext = businessContext;
        }

        public void Execute()
        {
            _police.Init(_businessContext.StartPoliceBeforeEndTime);
        }
    }
}
