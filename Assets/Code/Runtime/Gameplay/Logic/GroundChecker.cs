using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius = 0.2f;

        public bool IsGrounded()
        {
            return Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundCheckRadius, _groundLayer);
        }

        private void OnDrawGizmosSelected()
        {
            if (_groundCheck != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(_groundCheck.position, _groundCheck.position + Vector3.down * _groundCheckRadius);
            }
        }
    }
}