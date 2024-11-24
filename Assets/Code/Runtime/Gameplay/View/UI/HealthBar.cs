using Code.Runtime.Gameplay.Logic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Image _image;
        
        private Health _health;
        
        
        
        private void OnDestroy() =>
            _health.Changed -= OnChanged;

        public void OnChanged()
        {
            _image.fillAmount =  _health.CurrentHealth /  _health.MaxHealth;
        }
        
        public void SetUp(Health health)
        {
            _health = health;
            _health.Changed += OnChanged;
        }

        
    }
}