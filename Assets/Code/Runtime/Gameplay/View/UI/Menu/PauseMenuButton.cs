using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.Services.Scene;
using UnityEngine;
using Zenject;
namespace Code.Runtime.Gameplay.View.UI.Menu
{
    public class MenuButton : MonoBehaviour
    {
        public GameObject PauseGameMenu;
        private IGameStateMachine _gameStateMachine;
        private PauseGameState _pauseGameState;
        private const string LevelNameScene = "Level";

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine, PauseGameState pauseGameState)
        {
            _gameStateMachine = gameStateMachine;
            _pauseGameState = pauseGameState;
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if (_pauseGameState.PauseGame)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGameMethod();
                }
            }
        }
        public void RestartGame()
        {
            Time.timeScale = 1f;
            _gameStateMachine.Enter<LoadLevelState, string>(LevelNameScene);
        }
        public void ResumeGame()
        {
            PauseGameMenu.SetActive(false);
            Time.timeScale = 1f;
            _gameStateMachine.Enter<LevelState>();
        }
        
        public void PauseGameMethod()
        {
            PauseGameMenu.SetActive(true);
            Time.timeScale = 0f;
            _gameStateMachine.Enter<PauseGameState>();
        }
        
        public void LoadMenu()
        {
            Time.timeScale = 1;
            _gameStateMachine.Enter<MenuState>();
        }
    }
}