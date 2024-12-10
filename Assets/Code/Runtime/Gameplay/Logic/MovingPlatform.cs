using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class MovingPlatform : MonoBehaviour
    {
        public Vector3 pointA;
        public Vector3 pointB;

        [SerializeField]
        public float speed = 2.0f;

        private Vector3 targetPosition;

        void Start()
        {
            targetPosition = pointB;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = targetPosition == pointA ? pointB : pointA;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green; 
            Gizmos.DrawLine(pointA, pointB);

            Gizmos.color = Color.red; 
            Gizmos.DrawSphere(pointA, 0.2f);
            Gizmos.DrawSphere(pointB, 0.2f);
        }
    }
}