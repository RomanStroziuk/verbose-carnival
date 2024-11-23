using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.Infrastructure.Services.Scene;
using Zenject;

namespace Code.Runtime.Infrastructure
{
    public class ProjectInstaller : MonoInstaller , IInitializable
    {
        public override void InstallBindings()
        {
            Container.Bind<IRandomService>().To<RandomService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<ProjectInstaller>().FromInstance(this).AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<ISceneLoader>().LoadScene("Level");
        }
    }
}