using Code.Runtime.Data;
using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.Services.CleaningService;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.WindowsService;

namespace Code.Runtime.Infrastructure.Services.WindowButtonsService
{
    public class WindowButtonsService : IWindowButtonsService
    {
        private ISceneLoader _sceneLoader;
        private ICleaningService _cleaningService;
        private IGameStateMachine _gameStateMachine;
        private IInputService _inputService;
        private IWindowService _windowService;

        public WindowButtonsService(
            ISceneLoader sceneLoader,
            ICleaningService cleaningService,
            IGameStateMachine gameStateMachine,
            IInputService inputService,
            IWindowService windowService)
        {
            _inputService = inputService;
            _windowService = windowService;
            _sceneLoader = sceneLoader;
            _cleaningService = cleaningService;
            _gameStateMachine = gameStateMachine;
        }

        public void PressPauseButton()
        {
            _windowService.OpenWindow(WindowTypeId.Pause);
            _inputService.Disable();
        }

        public void PressExitButton(string bootstrapSceneMenu)
        {
            _windowService.CloseWindow();
            _cleaningService.CleanLevel();
            _sceneLoader.LoadScene(bootstrapSceneMenu);
            _gameStateMachine.Enter<BootstrapState>();
        }

        public void PressRestartButton(string levelName)
        {
            _cleaningService.CleanLevel();
            _windowService.CloseWindow();
            _sceneLoader.LoadScene(levelName);
            _gameStateMachine.Enter<LoadLevelState, string>("Level");
        }

        public void PressResumeButton()
        {
            _windowService.CloseWindow();
            _inputService.Enable();
        }
    }
}