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
        
        [SerializeField]
        private PunchAnimator _punchAnimator;
        private IWalletService _wallet;
        private int _lastVelue;

        [Inject]
        private void Construct(IWalletService wallet)
        {
            _wallet = wallet;
        }
        private void Update()
        {
            int newVelue = _wallet.Balance;
                if(_lastVelue != newVelue )
                    _punchAnimator.Animate();
                    
            _coinText.text = newVelue.ToString();
                _lastVelue = newVelue;
        }
    }
}
