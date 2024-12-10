using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundCheckRadius = 0.2f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Jumper _jumper;

        private void Update()
        {
            if (IsGrounded())
            {
                _jumper.ResetJumps();  // Скидаємо стрибки при приземленні
            }
        }

        private bool IsGrounded()
        {
            // Перевіряємо, чи персонаж торкається землі
            return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
        }
    }
}