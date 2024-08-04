using System.Threading.Tasks;
using SlotMachine.Business.Common;

namespace SlotMachine.Game.Domain.CoinSlot.Events
{
    public class CoinSlotAddCoinEvent
    {
        private CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler _coinSlotEventExecuteUseCaseHandler;

        public CoinSlotAddCoinEvent(
            CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler coinSlotEventExecuteUseCaseHandler
        )
        {
            _coinSlotEventExecuteUseCaseHandler = coinSlotEventExecuteUseCaseHandler;
        }

        public Task Notify(CoinType coinType)
        {
            _coinSlotEventExecuteUseCaseHandler.Handle(coinType);

            return Task.CompletedTask;
        }
    }
}


