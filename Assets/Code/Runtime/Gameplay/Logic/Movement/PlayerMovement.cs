using Code.Runtime.Gameplay.Logic.Platform;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rb2d;
        private PlatformMovement _currentPlatformMovement;
        private Vector2 lastPlatformPosition;

        void Start()
        {
            _rb2d = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            PlatformMovement platformMovement = collision.gameObject.GetComponent<PlatformMovement>();
            if (platformMovement != null)
            {
                _currentPlatformMovement = platformMovement;
                lastPlatformPosition = platformMovement.transform.position;
            }
        }

        void OnCollisionStay2D()
        {
            if (_currentPlatformMovement != null)
            {
                Vector2 platformCurrentPosition = _currentPlatformMovement.transform.position;
                Vector2 platformMovement = platformCurrentPosition - lastPlatformPosition;

                transform.position += (Vector3)platformMovement;

                lastPlatformPosition = platformCurrentPosition;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<PlatformMovement>() == _currentPlatformMovement)
            {
                _currentPlatformMovement = null;
            }
        }
    }
}