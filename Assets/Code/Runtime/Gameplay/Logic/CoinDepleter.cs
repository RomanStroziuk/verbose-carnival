using UnityEngine;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class CoinDepleter : MonoBehaviour, ICollecteble
    {
        [SerializeField]
        private int _minCoinAmountToRemove = 5; 
        [SerializeField]
        private int _maxCoinAmountToRemove = 20;

        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;

        public bool IsCollected { get; private set; }

        [Inject]
        private void Construct(IWalletService walletService, ISaveLoadService saveLoadService)
        {
            _walletService = walletService;
            _saveLoadService = saveLoadService;
        }

        public void Collect(Collector collector)
        {
            int coinsToRemove = Random.Range(_minCoinAmountToRemove, _maxCoinAmountToRemove + 1);
            _walletService.RemoveCoins(coinsToRemove);
            _saveLoadService.SaveProgress();
            IsCollected = true;

            Destroy(gameObject);
        }
    }
}