using UnityEngine;

namespace Code.Runtime.Gameplay.Logic
{
    public class Mace : MonoBehaviour, ICollecteble
    {
        [SerializeField]
        private float _healthToSubstract = 10;
        public void Collect(Collector collector)
        {
            collector.GetComponent<Health>().Substract(_healthToSubstract);
        }
    }
}