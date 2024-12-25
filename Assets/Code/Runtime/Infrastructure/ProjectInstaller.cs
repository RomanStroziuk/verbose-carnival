using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.Factories;
using Code.Runtime.Infrastructure.GameStates.Provider;
using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.SaveLoadRegistry;
using Code.Runtime.Infrastructure.Services.CleaningService;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using Code.Runtime.Infrastructure.Services.Progress;
using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.Shop;
using Code.Runtime.Infrastructure.Services.Sounds;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.Infrastructure.Services.TimeService;
using Code.Runtime.Infrastructure.Services.WindowButtonsService;
using Code.Runtime.Infrastructure.WindowsService;
using Zenject;

namespace Code.Runtime.Infrastructure
{
    public class ProjectInstaller : MonoInstaller, IInitializable
    {
        public override void InstallBindings()
        {
            BindInfrastructureServices();
            BindGameStates();
            BindFactories();
            BindGameplayServices();
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameplayServices()
        {
            Container.Bind<IWalletService>().To<WalletService>().AsSingle();
            Container.Bind<IShopService>().To<ShopService>().AsSingle();
            Container.Bind<IPlayerInventoryService>().To<PlayerInventoryService>().AsSingle();
        }
        
        private void BindFactories()
        {
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<IStateProvider>().To<StateProvider>().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadProgressState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MenuState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadLevelState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelState>().AsSingle();
        }

        private void BindInfrastructureServices()
        {
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<IProgressService>().To<ProgressService>().AsSingle();
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
            Container.Bind<ISaveLoadRegistryService>().To<SaveLoadRegistryService>().AsSingle();
            Container.Bind<ISoundService>().To<SoundService>().AsSingle();
            Container.Bind<ICleaningService>().To<CleaningService>().AsSingle();
            Container.Bind<ITimeService>().To<TimeService>().AsSingle();
            Container.Bind<IWindowService>().To<WindowService>().AsSingle();
            Container.Bind<IWindowButtonsService>().To<WindowButtonsService>().AsSingle();
        }

        public void Initialize()
        {
            Container
                .Resolve<IGameStateMachine>()
                .Enter<BootstrapState>();
        }
    }
}