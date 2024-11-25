using System.ComponentModel;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Coin : MonoBehaviour, ICollecteble
    {
        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;
        public bool IsCollected { get; private set; }

        [Inject]
        private void Construct(IWalletService walletService, ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            _walletService = walletService;
        }

        public void Collect(Collector collector)
        {
            _walletService.AddCoin();
            _saveLoadService.SavePrograss();
            Destroy(gameObject);
        }
        
        
    }
}