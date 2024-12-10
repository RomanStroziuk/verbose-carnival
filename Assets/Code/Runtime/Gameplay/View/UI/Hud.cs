using Code.Runtime.Gameplay.Logic;
using UnityEngine;

namespace Code.Runtime.Gameplay.View.UI
{
    public sealed class Hud : MonoBehaviour
    {
        [SerializeField]
        private CoinView _coinView;
        
        [SerializeField]
        private HealthBar _healthBar;
        
        public void SetUp( Health health)
        {
            _healthBar.SetUp(health);
        }
        
    }
}