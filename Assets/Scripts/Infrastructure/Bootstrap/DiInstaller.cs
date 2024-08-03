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
using SlotMachine.Business.Domain.Inventory;
using SlotMachine.Game.Domain.Inventory.Events;
using SlotMachine.Business.Domain.StageTimer;
using SlotMachine.Business.Domain.StageTimer.Events;
using SlotMachine.Business.Domain.Police;
using SlotMachine.Business.Domain.Bonus;
using SlotMachine.Business.Common.UseCases;
using SlotMachine.Business.Domain.Health;
using SlotMachine.Business.Domain.Health.UseCases;

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
            Container.Bind(typeof(IInventory), typeof(IInventoryInfo)).To<Inventory>().AsSingle();
            Container.Bind(typeof(IStageTimer), typeof(IStageTimerInfo)).To<StageTimer>().AsSingle();
            Container.Bind(typeof(IPoliceInfo)).To<Police>().AsSingle();
            Container.Bind(typeof(IBonusInfo)).To<Bonus>().AsSingle();
            Container.Bind(typeof(IHealth), typeof(IHealthInfo)).To<Health>().AsSingle();

            Container.Bind<IRepository>().To<Repository.Repository>().AsSingle();
            Container.Bind<ILocalStorageService>().To<LocalStorageService>().AsSingle();
            Container.Bind<IDataBaseService>().To<DataBaseService>().AsSingle();
        }

        private void BindEvents()
        {
            //// SlotMachinePlayEvent
            Container.Bind<SlotMachinePlayEvent>().AsTransient();
            Container.Bind<SlotMachineSlotMachinePlayEventExecuteUseCaseHandler>().AsTransient();
            Container.Bind<SlotMachineEventUpdateViewHandler>().AsTransient();

            //// CoinsOnTapEvent
            Container.Bind<CoinsOnTapEvent>().AsTransient();
            Container.Bind<CoinsOnTapEventExecuteUseCaseHandler>().AsTransient();
            Container.Bind<CoinsEventUpdateViewHandler>().AsTransient();

            //// CoinSlotEventUpdateViewHandler
            Container.Bind<CoinSlotEventUpdateViewHandler>().AsTransient();

            //// CoinSlotAddCoinEvent
            Container.Bind<CoinSlotAddCoinEvent>().AsTransient();
            Container.Bind<CoinSlotAddCoinEventEnceaseCoinsUseCaseHandler>().AsTransient();

            //// CoinSlotReturnCoinEvent
            Container.Bind<CoinSlotReturnCoinEvent>().AsTransient();
            Container.Bind<CoinSlotReturnCoinsEventExecuteUseCaseHandler>().AsTransient();

            Container.Bind<TokensAddEvent>().AsTransient();
            Container.Bind<TokensAddEventExecuteUseCaseHandler>().AsTransient();
            Container.Bind<TokensEventUpdateViewHandler>().AsTransient();
            
            //// State
            Container.Bind<StateEventUpdateViewHandler>().AsTransient();

            Container.Bind<StateAddDamageEventExecuteUseCaseHandler>().AsTransient();
            Container.Bind<StateAddDamageEvent>().AsTransient();

            Container.Bind<StateRepairEvent>().AsTransient();
            Container.Bind<StateRepairEventExecuteUseCaseHandler>().AsTransient();

            Container.Bind<InventorySelectWeaponEvent>().AsTransient();
            Container.Bind<InventorySelectWeaponEventExecuteUseCaseHandler>().AsTransient();


            Container.Bind<StageTimerStartEvent>().AsTransient();
            Container.Bind<StageTimerStartEventExecuteUseCaseHandler>().AsTransient();

        }

        private void BindUseCases()
        {
            //// common
            Container.Bind<HitUseCase>().AsTransient();
            Container.Bind<StageStartUseCase>().AsTransient();

            //// SlotMachine
            Container.Bind<SlotMachinePlayUseCase>().AsTransient();

            //// Coins
            Container.Bind<CoinsEncreaseUseCase>().AsTransient();
            Container.Bind<CoinsSaveUseCase>().AsTransient();
            Container.Bind<CoinsAddUseCase>().AsTransient();
            Container.Bind<CoinsTryDecreaseUseCase>().AsTransient();
            
            //// CoinSlot
            Container.Bind<CoinSlotEncreaseCoinsUseCase>().AsTransient();
            Container.Bind<CoinSlotReturnCoinsUseCase>().AsTransient();

            //// Tokens
            Container.Bind<TokensAddUseCase>().AsTransient();

            //// State
            Container.Bind<StateAddDamageUseCase>().AsTransient();
            Container.Bind<StateRepairUseCase>().AsTransient();

            //// Inventory
            Container.Bind<InventorySelectWeaponUseCase>().AsTransient();

            //// StageTimer
            Container.Bind<StageTimerStartUseCase>().AsTransient();
            Container.Bind<StageTimerStopUseCase>().AsTransient();

            //// HealthTryDamageUseCase
            Container.Bind<HealthTryDamageUseCase>().AsTransient();
            Container.Bind<HealthStartRepairUseCase>().AsTransient();
            
        }
    }
}