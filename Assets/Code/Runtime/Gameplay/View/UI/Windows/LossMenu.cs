using Code.Runtime.Infrastructure.Services.WindowButtonsService;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Windows
{
    public class LossMenu : MonoBehaviour
    {
        private const string BootstrapSceneMenu = "BootstrapScene";
        private readonly string LevelName = "Level";
        
        [SerializeField]
        GameObject lossMenu;

        private IWindowButtonsService _windowButtonsService;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService)
        {
            _windowButtonsService = windowButtonsService;
        }
        
        public void Restart()
        {
            _windowButtonsService.PressRestartButton(BootstrapSceneMenu);
        }
        
        public void ExitToMenu()
        {
            _windowButtonsService.PressExitButton(LevelName);
        }
    }
}