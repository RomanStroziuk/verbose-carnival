using Code.Runtime.Gameplay.Logic.Sounds; 
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.Services.Scene;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public sealed class MenuState : IEnterableState
    {
        private const string MenuSceneName = "Menu";
        
        private const string PauseMusicName = "PauseGame";
        private const string ActiveGameName = "ActiveGame"; 
        private const string MenuMusicName = "StartMenu";
        private const float FadeDuration = 1f;                
        
        private readonly ISceneLoader _sceneLoader;

        public MenuState(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(MenuSceneName);

            if (AudioManager.instance != null)
            {
                AudioManager.instance.FadeOut(PauseMusicName, FadeDuration);
                AudioManager.instance.FadeOut(ActiveGameName, FadeDuration); 
                
                AudioManager.instance.FadeIn(MenuMusicName, 0.1f, FadeDuration);
            }
        }
    }
}