using Code.Runtime.Gameplay.Service.Wallet;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
         
        [SerializeField] 
        private TextMeshProUGUI _coinText;
        
        
        private IWalletService _wallet;

        [Inject]
        private void Construct(IWalletService wallet)
        {
            _wallet = wallet;
        }
        private void Update()
        {
            _coinText.text = _wallet.Balance.ToString();
        }

    }
}