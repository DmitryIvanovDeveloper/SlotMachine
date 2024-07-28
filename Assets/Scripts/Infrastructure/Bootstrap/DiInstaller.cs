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

            Container.Bind<IRepository>().To<Repository.Repository>().AsSingle();
            Container.Bind<ILocalStorageService>().To<LocalStorageService>().AsSingle();
            Container.Bind<IDataBaseService>().To<DataBaseService>().AsSingle();
        }

        private void BindEvents()
        {
            //// SlotMachinePlayEvent
            Container.Bind<SlotMachinePlayEvent>().AsSingle();
            Container.Bind<SlotMachineSlotMachinePlayEventExecuteUseCaseHandler>().AsSingle();
            Container.Bind<SlotMachineSlotMachinePlayUpdateViewHandler>().AsSingle();

            Container.Bind<CoinsOnTapEvent>().AsSingle();
            Container.Bind<CoinsOnTapEventExecuteUseCaseHandler>().AsSingle();
            Container.Bind<CoinsOnTapEventUpdateViewHandler>().AsSingle();
        }

        private void BindUseCases()
        {
            //// SlotMachine
            Container.Bind<SlotMachinePlayUseCase>().AsSingle();

            //// Coins
            Container.Bind<CoinsEncreaseUseCase>().AsSingle();
            Container.Bind<CoinsSaveUseCase>().AsSingle();
            Container.Bind<CoinsAddUseCase>().AsSingle();
        }
    }
}