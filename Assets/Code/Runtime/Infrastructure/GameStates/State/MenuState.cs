using Code.Runtime.Infrastructure.Services.Scene;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public sealed class MenuState : IEnterableState
    {
        private const string MenuSceneName = "Menu";
        private readonly ISceneLoader _sceneLoader;
        public MenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
        public void Enter() => _sceneLoader.LoadScene(MenuSceneName);
    }
}