using System.ComponentModel;
using Code.Runtime.Gameplay.Service.Wallet;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Coin : MonoBehaviour, ICollecteble
    {
        private IWalletService _walletService;

        public bool IsCollected { get; private set; }

        [Inject]
        private void Construct(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public void Collect(Collector collector)
        {
            _walletService.AddCoin();
            Destroy(gameObject);
        }
        
        
    }
}