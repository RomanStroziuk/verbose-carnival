using Code.Runtime.Infrastructure.Services.Random;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class HealthPack : MonoBehaviour, ICollecteble, IPlaySound
    {
        [SerializeField]
        private float _minHealingAmount = 5f;

        [SerializeField]
        private float _maxHealingAmount = 20f;

        [SerializeField]
        private AudioClip _collectSound;

        private AudioSource _audioSource; 
        public bool IsCollected { get; private set; }

        private IRandomService _randomService;

        [Inject]
        private void Construct(IRandomService randomService)
        {
            _randomService = randomService;
        }

        private void Awake()
        {
            _audioSource = gameObject.GetComponent<AudioSource>() ?? gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = false;
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

            PlaySound();

            HideObject();

            Destroy(gameObject, _collectSound.length);
        }

        public void PlaySound()
        {
            if (_audioSource != null && _collectSound != null)
            {
                _audioSource.clip = _collectSound;
                _audioSource.Play();
            }
        }

        private void HideObject()
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null) renderer.enabled = false;

            Collider collider = GetComponent<Collider>();
            if (collider != null) collider.enabled = false;
        }
    }
}
