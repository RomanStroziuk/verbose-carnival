using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb2d;
        private Vector2 platformVelocity;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void OnCollisionStay2D(Collision2D collision)
        {
            MovingPlatform movingPlatform = collision.gameObject.GetComponent<MovingPlatform>();
            if (movingPlatform != null)
            {
                // Отримуємо швидкість платформи
                platformVelocity = movingPlatform.GetComponent<Rigidbody2D>().velocity;

                // Застосовуємо рух платформи до гравця
                rb2d.velocity = new Vector2(platformVelocity.x, rb2d.velocity.y);

                // Оновлюємо позицію гравця відносно платформи
                Vector2 platformMovement = (Vector2)movingPlatform.transform.position - collision.contacts[0].point;
                rb2d.position += platformMovement;
            }
        }
    }
}