using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Gameplay.View;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Coin : MonoBehaviour, ICollecteble, IPlaySound
    {
        [FormerlySerializedAs("moveFader")] [FormerlySerializedAs("_moveFadeDestroyer")] [SerializeField]
        private MoveFaderDestroy moveFaderDestroy;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;

        [SerializeField] private AudioClip _collectSound; 

        private AudioSource _audioSource;
        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;

        public bool IsCollected { get; private set; }

        [Inject]
        private void Construct(IWalletService walletService, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _walletService = walletService;
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

            _walletService.AddCoin();
            _saveLoadService.SaveProgress();

            PlaySound();

            HideObject();

            Destroy(gameObject, _collectSound != null ? _collectSound.length : 0.1f);
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

            if (_collider2D != null) _collider2D.enabled = false;

            if (_rigidbody2D != null) Destroy(_rigidbody2D);

            moveFaderDestroy?.Destroy();
        }
    }
}
