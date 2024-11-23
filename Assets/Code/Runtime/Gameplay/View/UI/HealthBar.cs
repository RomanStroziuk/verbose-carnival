using Code.Runtime.Gameplay.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Runtime.Gameplay.View.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        
        [SerializeField]
        private Health _health;

        private void Awake()
        {
            _health.Changed += OnChanged;
        }
        
        private void OnDestroy() =>
        _health.Changed -= OnChanged;

        public void OnChanged()
        {
            _image.fillAmount = _health.CurrentHealth / _health.MaxHealth;
        }

        
    }
}