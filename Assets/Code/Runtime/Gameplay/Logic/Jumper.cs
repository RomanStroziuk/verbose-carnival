using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
     public class Jumper : MonoBehaviour
        {
            [SerializeField] private Rigidbody2D _rigidBody;
            [SerializeField] private float _jumpForce = 5f;
            [SerializeField] private LayerMask _groundLayer;
            [SerializeField] private Transform _groundCheck;
            [SerializeField] private float _groundCheckRadius = 0.2f;
    
            private bool _isGrounded;
    
            private void Update()
            {
                CheckGrounded();
            }
    
            private void CheckGrounded()
            {
                _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
            }
    
            public void Jump()
            {
                if (_isGrounded)
                {
                    _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
                }
            }
        }
}