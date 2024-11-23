using Code.Runtime.Gameplay.Logic;
using TMPro;
using UnityEngine;

namespace Code.Runtime.Gameplay.View.UI
{
    public class CoinView : MonoBehaviour
    {
        [SerializeField] 
        private Wallet _wallet;

        [SerializeField] 
        private TextMeshProUGUI _coinText;

        private void Update()
        {
            _coinText.text = _wallet.Balance.ToString();
        }

    }
}