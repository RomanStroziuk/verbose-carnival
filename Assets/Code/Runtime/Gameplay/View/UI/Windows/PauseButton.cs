using Code.Runtime.Infrastructure.Services.WindowButtonsService;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI.Windows
{
    public class PauseButton : MonoBehaviour
    {
        private IWindowButtonsService _windowButtonsService;

        [Inject]
        private void Construct(IWindowButtonsService windowButtonsService)
        {
            _windowButtonsService = windowButtonsService;
        }

        public void Pause()
        {
            _windowButtonsService.PressPauseButton();
        }
    }
}