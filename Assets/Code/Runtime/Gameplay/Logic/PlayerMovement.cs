using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        private MovingPlatform currentPlatform;
        private Vector2 lastPlatformPosition;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            MovingPlatform movingPlatform = collision.gameObject.GetComponent<MovingPlatform>();
            if (movingPlatform != null)
            {
                currentPlatform = movingPlatform;
                lastPlatformPosition = movingPlatform.transform.position;
            }
        }

        void OnCollisionStay2D()
        {
            if (currentPlatform != null)
            {
                Vector2 platformCurrentPosition = currentPlatform.transform.position;
                Vector2 platformMovement = platformCurrentPosition - lastPlatformPosition;

                transform.position += (Vector3)platformMovement;

                lastPlatformPosition = platformCurrentPosition;
            }
        }

        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<MovingPlatform>() == currentPlatform)
            {
                currentPlatform = null;
            }
        }
    }
}