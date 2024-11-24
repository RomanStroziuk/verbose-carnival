using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Infrastructure.Services.Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
         
        [SerializeField] 
        private TextMeshProUGUI _coinText;
        
        
        private Wallet _wallet;


        private void Update()
        {
            _coinText.text = _wallet.Balance.ToString();
        }

        public void SetUp(Wallet wallet)
        {
            _wallet = wallet;
        }

    }
}