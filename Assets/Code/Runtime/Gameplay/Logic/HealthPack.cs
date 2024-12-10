using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class HealthPack : MonoBehaviour, ICollecteble
    {
        [SerializeField]
        private float _minHealingAmount = 5f;
        
        [SerializeField]
        private float _maxHealingAmount = 20f;

        public bool IsCollected { get; private set; }

        public void Collect(Collector collector)
        {
            if (IsCollected) return; 

            IsCollected = true;

            float healingAmount = Random.Range(_minHealingAmount, _maxHealingAmount);

            Health health = collector.GetComponent<Health>();
            if (health != null)
            {
                health.AddHealth(healingAmount);
            }

            Destroy(gameObject);
        }
    }
}