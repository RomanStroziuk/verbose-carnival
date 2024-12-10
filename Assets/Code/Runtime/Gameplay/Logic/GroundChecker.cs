using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius = 0.2f;
        [SerializeField] private float _groundRayLength = 1f; 

        private bool _isGrounded;

        public bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundRayLength, _groundLayer);
            return hit;
        }
    }
}