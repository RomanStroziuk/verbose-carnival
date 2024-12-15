using Code.Runtime.Gameplay.Logic.Sounds; 
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.Services.Scene;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public sealed class PauseGameState : IEnterableState, IExitableState
    {
        public bool PauseGame = false;
        
        private const string MenuMusicName = "PauseGame";
        private const string ActiveName = "ActiveGame";

        public void Enter()
        {
            PauseGame=true;
            if (AudioManager.instance != null)
            {
                
                AudioManager.instance.StopAll();
                AudioManager.instance.FadeIn(MenuMusicName, 0.1f, 1f);
            }
        }
        
        public void Exit()
        {
            PauseGame=false;
        }
    }
}