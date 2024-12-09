using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerInputX : MonoBehaviour
    {
        [SerializeField] private MoverX _mover;
        [SerializeField] private Jumper _jumper;

        private IInputService _inputService;

        private JumpTypeId _currentJumpType = JumpTypeId.None;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void SetJumpType(JumpTypeId jumpType)
        {
            _currentJumpType = jumpType;
            _jumper.SetJumpType(jumpType);
        }

        private void Update()
        {
            float movement = _inputService.GetMovement();
            _mover.Move(movement);

            if (_inputService.IsJumping() && _currentJumpType != JumpTypeId.None)
            {
                _jumper.Jump();
            }
        }
    }
}