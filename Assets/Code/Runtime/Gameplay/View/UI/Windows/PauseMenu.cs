using Code.Runtime.Infrastructure.Services.WindowButtonsService;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Windows
{
    public class PauseMenu : MonoBehaviour
    {
        private const string BootstrapSceneMenu = "BootstrapScene";
        private readonly string LevelName = "Level";

        [SerializeField] GameObject pauseMenu;

        private IWindowButtonsService _windowButtonsService;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService)
        {
            _windowButtonsService = windowButtonsService;
        }

        public void Resume()
        {
            _windowButtonsService.PressResumeButton();
        }

        public void Restart()
        {
            _windowButtonsService.PressRestartButton(LevelName);
        }

        public void ExitToMenu()
        {
            _windowButtonsService.PressExitButton(BootstrapSceneMenu);
        }
    }
}