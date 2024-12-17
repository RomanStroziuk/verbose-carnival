using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Platform
{
    public class PlatformMovement : MonoBehaviour
    {
        public Vector3 pointA;
        public Vector3 pointB;

        [SerializeField]
        public float speed = 1.0f;
        
        [SerializeField]
        private float targetThreshold = 0.1f;


        private Vector3 _targetPosition;

        void Start()
        {
            _targetPosition = pointB;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _targetPosition) < targetThreshold)
            {
                _targetPosition = _targetPosition == pointA ? pointB : pointA;
            }
        }
    }
}