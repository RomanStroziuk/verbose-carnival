using Code.Runtime.Infrastructure.Factories;
using Code.Runtime.Infrastructure.GameStates;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.StaticData;
using Zenject;

namespace Code.Runtime.Infrastructure
{
    public class ProjectInstaller : MonoInstaller , IInitializable
    {
        public override void InstallBindings()
        {
           BindInfrastructureServices();
           BindGameStates();
           BindFactories();
            
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        private void BindFactories()
        {
            
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

            
        }
        
        private void BindGameStates()
        {
            Container.Bind<IStateProvider>().To<StateProvider>().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
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
        }

        public void Initialize()
        {
            Container
                .Resolve<IGameStateMachine>()
                .Enter<BootstrapState>();
        }
    }
}