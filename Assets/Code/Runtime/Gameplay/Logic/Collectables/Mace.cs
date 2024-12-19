﻿using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class Mace : MonoBehaviour, ICollecteble
    {
        [SerializeField]
        private float _healthToSubstract = 10;
        
        public bool IsCollected { get; private set; }
        public void Collect(Collector collector)
        {
            IsCollected = true;
            collector.GetComponent<Health>().Substract(_healthToSubstract);
        }
    }
}