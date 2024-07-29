using Zenject;

using SlotMachine.Business.Domain.SlotMachine;
using SlotMachine.Game.Domain.SlotMachine.Events;
using SlotMachine.Business.Domain.SlotMachine.UseCase;
using SlotMachine.Business.Domain.Coins.UseCases;
using SlotMachine.Game.Domain.Coins.Events;
using SlotMachine.Business.Domain.Coins;
using SlotMachine.Business.Adapters;
using SlotMachine.Infrastructure.Repository.Adapters;
using SlotMachine.Infrastructure.Services;
using SlotMachine.Game.Domain.CoinSlot.Events;
using SlotMachine.Business.Domain.CoinSlot.UseCases;
using SlotMachine.Business.Domain.CoinSlot;
using SlotMachine.Business.Domain.Tokens;
using SlotMachine.Business.Domain.Tokens.UseCase;
using SlotMachine.Game.Domain.Tokens.Events;
using SlotMachine.Business.Domain.State;
using SlotMachine.Business.Domain.State.UseCase;
using SlotMachine.Game.Domain.State.Events;

namespace SlotMachine.Infrastructure.Bootstrap
{
    public class DiInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMediator();
            BindEvents();
            BindUseCases();
        }

        private void BindMediator()
        {
            Container.Bind(typeof(ISlotMachine), typeof(ISlotMachineInfo)).To<Business.Domain.SlotMachine.SlotMachine>().AsSingle();
            Container.Bind(typeof(ICoins), typeof(ICoinsInfo)).To<Coins>().AsSingle();
            Container.Bind(typeof(ICoinSlot), typeof(ICoinSlotInfo)).To<CoinSlot>().AsSingle();
            Container.Bind(typeof(ITokens), typeof(ITokensInfo)).To<Tokens>().AsSingle();
            Container.Bind(typeof(IState), typeof(IStateInfo)).To<State>().AsSingle();

            Container.Bind<IRepository>().To<Repository.Repository>().AsSingle();
            Container.Bind<ILocalStorageService>().To<LocalStorageService>().AsSingle();
            Container.Bind<IDataBaseService>().To<DataBaseService>().AsSingle();
        }

        private void BindEvents()
        {
            //// SlotMachinePlayEvent
            Container.Bind<SlotMachinePlayEvent>().AsSingle();
            Container.Bind<SlotMachineSlotMachinePlayEventExecuteUseCaseHandler>().AsSingle();
            Container.Bind<SlotMachineEventUpdateViewHandler>().AsSingle();

            //// CoinsOnTapEvent
            Container.Bind<CoinsOnTapEvent>().AsSingle();
            Container.Bind<CoinsOnTapEventExecuteUseCaseHandler>().AsSingle();
            Container.Bind<CoinsEventUpdateViewHandler>().AsSingle();

            //// CoinSlotEventUpdateViewHandler
            Container.Bind<CoinSlotEventUpdateViewHandler>().AsSingle();

            //// CoinSlotAddCoinEvent
            Container.Bind<CoinSlotAddCoinEvent>().AsSingle();
            Container.Bind<CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler>().AsSingle();

            //// CoinSlotReturnCoinEvent
            Container.Bind<CoinSlotReturnCoinEvent>().AsSingle();
            Container.Bind<CoinSlotReturnCoinsEventExecuteUseCaseHandler>().AsSingle();

            Container.Bind<TokensAddEvent>().AsSingle();
            Container.Bind<TokensAddEventExecuteUseCaseHandler>().AsSingle();
            Container.Bind<TokensEventUpdateViewHandler>().AsSingle();
            
            //// State
            Container.Bind<StateEventUpdateViewHandler>().AsSingle();

            Container.Bind<StateAddDamageEventExecuteUseCaseHandler>().AsSingle();
            Container.Bind<StateAddDamageEvent>().AsSingle();

            Container.Bind<StateRepairEvent>().AsSingle();
            Container.Bind<StateRepairEventExecuteUseCaseHandler>().AsSingle();
        }

        private void BindUseCases()
        {
            //// SlotMachine
            Container.Bind<SlotMachinePlayUseCase>().AsSingle();

            //// Coins
            Container.Bind<CoinsEncreaseUseCase>().AsSingle();
            Container.Bind<CoinsSaveUseCase>().AsSingle();
            Container.Bind<CoinsAddUseCase>().AsSingle();
            Container.Bind<CoinsTryDecreaseUseCase>().AsSingle();
            
            //// CoinSlot
            Container.Bind<CoinSlotEncreaseCoinsUseCase>().AsSingle();
            Container.Bind<CoinSlotReturnCoinsUseCase>().AsSingle();

            //// Tokens
            Container.Bind<TokensAddUseCase>().AsSingle();

            //// State
            Container.Bind<StateAddDamageUseCase>().AsSingle();
            Container.Bind<StateRepairUseCase>().AsSingle();
            
        }
    }
}