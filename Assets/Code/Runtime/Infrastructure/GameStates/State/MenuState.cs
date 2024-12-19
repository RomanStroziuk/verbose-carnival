using Code.Runtime.Data;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.Sounds;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public sealed class MenuState : IEnterableState
    {
        private const string MenuSceneName = "Menu";

        private readonly ISceneLoader _sceneLoader;
        private ISoundService _soundService;

        public MenuState(ISceneLoader sceneLoader, ISoundService soundService)
        {
            _sceneLoader = sceneLoader;
            _soundService = soundService;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(MenuSceneName);
            
            _soundService.Play(SoundTypeId.MenuSound);
        }
    }
}