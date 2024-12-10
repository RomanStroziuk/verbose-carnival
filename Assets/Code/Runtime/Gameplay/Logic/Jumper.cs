using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private MoverY _moverY;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private int MaxJump;

        private int _remainingJumps;
        private JumpTypeId _currentJumpType = JumpTypeId.None;
        private bool Jumped = false;

        public void SetJumpType(JumpTypeId jumpType)
        {
            _currentJumpType = jumpType;
            _remainingJumps = jumpType == JumpTypeId.DoubleJump ? 2 : (jumpType == JumpTypeId.SingleJump ? 1 : 0);
        }

        private void Update()
        {
            if (_groundChecker.IsGrounded() && !Jumped)
            {
                Jumped = false;
                _remainingJumps = _currentJumpType == JumpTypeId.DoubleJump
                    ? 2
                    : (_currentJumpType == JumpTypeId.SingleJump ? 1 : 0);
            }
           
        }

        public void TryJump()
        {
            if (_remainingJumps > 0 && _currentJumpType != JumpTypeId.None)
            {
                Jumped = true;
                _remainingJumps--;
                _moverY.Jump();
            }
            else
            {
                Jumped = false;
            }
        }
    }
}