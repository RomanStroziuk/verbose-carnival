using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Death : MonoBehaviour
    {
        [SerializeField] private Health _health;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private float _forceonDeath;

        [SerializeField] private Collider2D _collider;

        private IInputService _inputService;

        private const string LevelMusicName = "ActiveGame";

        [Inject]
        private void Construct(IInputService inputService) =>
            _inputService = inputService;

        private void OnValidate()
        {
            _health ??= GetComponent<Health>();
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
            _collider ??= GetComponent<Collider2D>();
        }

        private void Awake() =>
            _health.Death += onDeath;

        private void OnDestroy() =>
            _health.Death -= onDeath;

        private void onDeath()
        {
            _inputService.Disable();

            _rigidbody2D.AddForce(Vector2.up * _forceonDeath, ForceMode2D.Impulse);
            _collider.enabled = false;

            if (AudioManager.instance != null)
            {
                AudioManager.instance.Stop(LevelMusicName);
            }
        }
    }
}