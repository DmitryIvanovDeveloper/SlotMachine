using System.Threading.Tasks;
using SlotMachine.Business.Domain.CoinSlot.UseCases;

namespace SlotMachine.Game.Domain.CoinSlot.Events
{
    public class CoinSlotReturnCoinsEventExecuteUseCaseHandler
    {
        private CoinSlotReturnCoinsUseCase _coinSlotReturnCoinsUseCase;

        public CoinSlotReturnCoinsEventExecuteUseCaseHandler(CoinSlotReturnCoinsUseCase coinSlotReturnCoinsUseCase)
        {
            _coinSlotReturnCoinsUseCase = coinSlotReturnCoinsUseCase;
        }

        public Task Handle()
        {
            _coinSlotReturnCoinsUseCase.Execute();
            return Task.CompletedTask;
        }
    }
}
