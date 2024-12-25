using System.Collections;
using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.Sounds;
using Code.Runtime.Infrastructure.WindowsService;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [SerializeField] private Rigidbody2D _rigidbody;

        [SerializeField] private float _feorceOnDeath;

        [SerializeField] private Collider2D _collaider;

        private readonly float _deathWindowPopUpTime = 2f;
        private const float FadeDuration = 2f;

        private IInputService _inputService;
        private IWindowService _windowService;
        private ISoundService _soundService;

        private void OnValidate()
        {
            _health ??= GetComponent<Health>();
            _rigidbody ??= GetComponent<Rigidbody2D>();
            _collaider ??= GetComponent<Collider2D>();
        }

        [Inject]
        private void Construct(IInputService inputService, IWindowService windowService, ISoundService soundService)
        {
            _inputService = inputService;
            _windowService = windowService;
            _soundService = soundService;
        }

        private void Awake()
        {
            _health.Death += OnDeath;
        }

        private void OnDestroy()
        {
            _health.Death -= OnDeath;
        }

        private void OnDeath()
        {
            _inputService.Disable();
            _soundService.FadeOutMusic(FadeDuration);
            _rigidbody.AddForce(Vector2.up * _feorceOnDeath, ForceMode2D.Impulse);
            _collaider.enabled = false;
            StartCoroutine(OpenDeathWindowAfterDelay());
        }

        private IEnumerator OpenDeathWindowAfterDelay()
        {
            yield return new WaitForSecondsRealtime(_deathWindowPopUpTime);
            _windowService.OpenWindow(WindowTypeId.Loss);
        }
    }
}