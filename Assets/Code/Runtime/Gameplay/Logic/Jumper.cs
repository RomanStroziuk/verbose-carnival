using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private int _maxJumpCount = 2;  // Максимальна кількість стрибків
        private int _remainingJumps;  // Залишок стрибків

        private void Start()
        {
            _remainingJumps = _maxJumpCount;  // Ініціалізуємо залишок стрибків
        }

        public void Jump()
        {
            if (_remainingJumps > 0)
            {
                _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
                _remainingJumps--;  // Зменшуємо кількість доступних стрибків
            }
        }

        public void ResetJumps()
        {
            // Скидаємо кількість стрибків після приземлення
            _remainingJumps = _maxJumpCount;
        }

        public void SetMaxJumpCount(int count)
        {
            _maxJumpCount = count;
            _remainingJumps = _maxJumpCount;
        }
    }
}