using UnityEngine;
using Code.Runtime.Infrastructure.Services.Input;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerJumpInput : MonoBehaviour
    {
        [SerializeField] private Jumper _jumper;

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            
            if (_inputService.GetJump())
            {
                _jumper.Jump();
            }
        }
    }
}