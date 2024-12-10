using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class MoverY : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _jumpForce = 5f;

        public void Jump()
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpForce);
        }
    }
}