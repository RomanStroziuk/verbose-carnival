using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.Services.Scene;
using UnityEngine;
using Zenject;
namespace Code.Runtime.Gameplay.View.UI.Menu
{
    public class DeathButton : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;
        private const string LevelNameScene = "Level";

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, PauseGameState pauseGameState)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void RestartGame()
        {
            Time.timeScale = 1f;
            _gameStateMachine.Enter<LoadLevelState, string>(LevelNameScene);
        }
        
        public void ResumeGame()
        {
            Time.timeScale = 1f;
            _gameStateMachine.Enter<LevelState>();
        }
        
        public void LoadMenu()
        {
            Time.timeScale = 1;
            _gameStateMachine.Enter<MenuState>();
        }
    }
}