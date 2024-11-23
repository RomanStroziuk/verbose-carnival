using System;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private float _currentHealth;
        
        public float CurrentHealth => _currentHealth;
        
        public float MaxHealth { get; private set; }

        private void Start()
        {
            MaxHealth = _currentHealth;
        }
        public void Substract(float healthToSubstract)
        {
            if (healthToSubstract < 0)
            {
                throw new InvalidOperationException("Cannot substract to a negative health");
            }
            _currentHealth -= healthToSubstract;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }
        }
    }
}