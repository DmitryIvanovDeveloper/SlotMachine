using System.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Business.Domain.CoinSlot.UseCases;

namespace SlotMachine.Game.Domain.CoinSlot.Events
{
    public class CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler
    {
        private CoinSlotEncreaseCoinsUseCase _coinSlotEncreaseCoinsUseCase;

        public CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler(CoinSlotEncreaseCoinsUseCase coinSlotEncreaseCoinsUseCase)
        {
            _coinSlotEncreaseCoinsUseCase = coinSlotEncreaseCoinsUseCase;
        }

        public Task Handle(CoinType coinType)
        {
            _coinSlotEncreaseCoinsUseCase.Execute(coinType);
            return Task.CompletedTask;
        }
    }

}

