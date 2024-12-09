using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 0.2f;
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _jumpForce = 5f;

        private bool _isGrounded;
        private int _remainingJumps;

        private JumpTypeId _currentJumpType = JumpTypeId.None;
        private IPlayerInventoryService _inventoryService;

        [Inject]
        private void Construct(IPlayerInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        private void Start()
        {
            SetJumpType(_inventoryService.SelectedJump);
        }

        public void SetJumpType(JumpTypeId jumpType)
        {
            _currentJumpType = jumpType;
            _remainingJumps = (int)jumpType;
        }

        private void Update()
        {
            _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

            if (_isGrounded)
            {
                _remainingJumps = _currentJumpType == JumpTypeId.DoubleJump ? 2 : (_currentJumpType == JumpTypeId.SingleJump ? 1 : 0);
            }

            if (Input.GetButtonDown("Jump") && _remainingJumps > 0 && _currentJumpType != JumpTypeId.None)
            {
                Jump();
            }
        }

        public void Jump()
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
            _remainingJumps--;
        }

        private void OnDrawGizmosSelected()
        {
            if (_groundCheck != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(_groundCheck.position, _groundCheckRadius);
            }
        }
    }
}
