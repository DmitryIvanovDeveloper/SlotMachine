using System.Threading.Tasks;
using SlotMachine.Business.Common;
using SlotMachine.Game.Domain.Coins.Events;

namespace SlotMachine.Game.Domain.CoinSlot.Events
{
    public class CoinSlotAddCoinEvent
    {
        private CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler _coinSlotEventExecuteUseCaseHandler;
        private CoinSlotEventUpdateViewHandler _coinSlotEventUpdateViewHandler;
        private CoinsEventUpdateViewHandler _coinsOnTapEventUpdateViewHandler;

        public CoinSlotAddCoinEvent(
            CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler coinSlotEventExecuteUseCaseHandler,
            CoinSlotEventUpdateViewHandler coinSlotEventUpdateViewHandler,
            CoinsEventUpdateViewHandler coinsOnTapEventUpdateViewHandler

        )
        {
            _coinSlotEventExecuteUseCaseHandler = coinSlotEventExecuteUseCaseHandler;
            _coinSlotEventUpdateViewHandler = coinSlotEventUpdateViewHandler;
            _coinsOnTapEventUpdateViewHandler = coinsOnTapEventUpdateViewHandler;
        }

        public Task Notify(CoinType coinType)
        {
            _coinSlotEventExecuteUseCaseHandler.Handle(coinType);
            _coinSlotEventUpdateViewHandler.Handle();
            _coinsOnTapEventUpdateViewHandler.Handle();

            return Task.CompletedTask;
        }
    }
}


