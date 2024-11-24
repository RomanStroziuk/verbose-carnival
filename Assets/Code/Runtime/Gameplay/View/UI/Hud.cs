using Code.Runtime.Gameplay.Logic;
using TMPro;
using UnityEngine;

namespace Code.Runtime.Gameplay.View.UI
{
    public sealed class Hud : MonoBehaviour
    {
        [SerializeField]
        private CoinView _coinView;
        
        [SerializeField]
        private HealthBar _healthBar;

        
        public void SetUp(Wallet wallet, Health health)
        {
            _coinView.SetUp(wallet);
            _healthBar.SetUp(health);
        }
        
    }
}