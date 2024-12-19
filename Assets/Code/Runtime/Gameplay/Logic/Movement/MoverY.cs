using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using Code.Runtime.Infrastructure.Services.Sounds;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Movement
{
    public class MoverY : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _jumpForce = 7f;
        [SerializeField] private GameObject _groundCheck;  
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundRayLength = 1f; 

        private int _remainingJumps = 0;
        private int _maxJumps = 0;
        private int _currentJumpType;
        private bool _isJumping;
        private ISoundService _soundService;
        
        [Inject]
        private void Construct(ISoundService soundService)
        {
            _soundService = soundService; 
        }
        
        private void Update()
        {
            if (IsGrounded() && !_isJumping)
            {
                _remainingJumps = 0; 
            }

            if (IsGrounded() && _isJumping)
            {
                _isJumping = false;
            }
        }

        public void SetJumpType(int jumpCurrent)
        {
            _currentJumpType = jumpCurrent;
            _maxJumps = _currentJumpType;
        }

        public void TryJump()
        {
            if (_remainingJumps != _maxJumps && _currentJumpType > 0)
            {
                _remainingJumps++; 
                _isJumping = true;
                Jump(); 
            }
        }

        private void Jump()
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            _soundService.Play(SoundTypeId.JumpSound);
        }

        private bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundCheck.transform.position, Vector2.down, _groundRayLength, _groundLayer);
            return hit.collider != null;
        }
    }
}
