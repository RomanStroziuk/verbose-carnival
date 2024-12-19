using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.Infrastructure.Services.Sounds;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class HealthKit : MonoBehaviour, ICollecteble
    {
        [SerializeField] private float _minHealingAmount = 5f;

        [SerializeField] private float _maxHealingAmount = 20f;
        
        public bool IsCollected { get; private set; }

        private IRandomService _randomService;
        private ISoundService _soundService;

        [Inject]
        private void Construct(IRandomService randomService, ISoundService soundService)
        {
            _randomService = randomService;
            _soundService = soundService;
        }

        public void Collect(Collector collector)
        {
            if (IsCollected) return;

            IsCollected = true;
            
            _soundService.Play(SoundTypeId.HealthKitSound);

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