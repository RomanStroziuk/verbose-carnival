using Code.Runtime.Infrastructure.Services.Random;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class HealthPack : MonoBehaviour, ICollecteble
    {
        [SerializeField]
        private float _minHealingAmount = 5f;
        
        [SerializeField]
        private float _maxHealingAmount = 20f;

        public bool IsCollected { get; private set; }

        private IRandomService _randomService;
        
        [Inject]
        private void Construct(IRandomService randomService)
        {
            _randomService = randomService;
        }
        public void Collect(Collector collector)
        {
            if (IsCollected) return; 

            IsCollected = true;

            float healingAmount = _randomService.Range(_minHealingAmount, _maxHealingAmount);

            Health health = collector.GetComponent<Health>();
            if (health != null)
            {
                health.AddHealth(healingAmount);
            }

            Destroy(gameObject);
        }
    }
}