using Code.Runtime.Infrastructure.GameStates;
using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.Infrastructure.Services.Scene;
using Zenject;

namespace Code.Runtime.Infrastructure
{
    public class ProjectInstaller : MonoInstaller , IInitializable
    {
        public override void InstallBindings()
        {
           BindInfrastructureServices();
           BindGameStates();
            
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        private void BindGameStates()
        {
            Container.Bind<IStateProvider>().To<StateProvider>().AsSingle();
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelState>().AsSingle();

            
        }

        private void BindInfrastructureServices()
        {
            
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }

        public void Initialize()
        {
            Container
                .Resolve<IGameStateMachine>()
                .Enter<BootstrapState>();
        }
    }
}