using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerInputY : MonoBehaviour
    {
        [SerializeField] private Jumper _jumper;

        private IInputService _inputService;
        private JumpTypeId _currentJumpType = JumpTypeId.None;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.IsJumping())
            {
                _jumper.TryJump();
            }
        }
    }
}