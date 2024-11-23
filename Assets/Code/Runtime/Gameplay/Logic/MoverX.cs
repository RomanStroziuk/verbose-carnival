using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class MoverX : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidBody;
        [SerializeField] private float _speed;
        public float Speed => _rigidBody.velocity.x;
        public bool IsMoving => _rigidBody.velocity.x != 0;

        public void Move(float input)
        {
            _rigidBody.velocity = new Vector2(input * _speed, _rigidBody.velocity.y);
        }
    }
}