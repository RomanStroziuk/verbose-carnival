using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.Sounds;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _forceOnDeath;

        [SerializeField] private Collider2D _collider;

        private IInputService _inputService;
        private ISoundService _soundService;
        
        private const float FadeDuration = 2f;

        [Inject]
        private void Construct(IInputService inputService, ISoundService soundService)
        {
            _inputService = inputService;
            _soundService = soundService;
        }

        private void OnValidate()
        {
            _health ??= GetComponent<Health>();
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
            _collider ??= GetComponent<Collider2D>();
        }

        private void Awake() =>
            _health.Death += OnDeath;

        private void OnDestroy() =>
            _health.Death -= OnDeath;

        private void OnDeath()
        {
            _inputService.Disable();

            _rigidbody2D.AddForce(Vector2.up * _forceOnDeath, ForceMode2D.Impulse);
            _collider.enabled = false;
            _soundService.FadeOutMusic(FadeDuration);

        }
    }
}