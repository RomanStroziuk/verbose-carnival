using System;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Health : MonoBehaviour
    {

        public float CurrentHealth;
        
        public float MaxHealth { get; private set; }  
        
        public event Action Changed;

        public event Action Death;

        private void Start()
        {
            MaxHealth = CurrentHealth;
        }
        public void Substract(float healthToSubstract)
        {
            if (healthToSubstract < 0)
            {
                throw new InvalidOperationException("Cannot substract to a negative health");
            }
            CurrentHealth -= healthToSubstract;
            Changed?.Invoke();

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Death?.Invoke();
            }
        }
    }
}