using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class CoinDestroyer : MonoBehaviour, ICollecteble
    {
        [SerializeField]
        private int _minCoinAmountToRemove = 5; 
        [SerializeField]
        private int _maxCoinAmountToRemove = 20;

        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;
        private IRandomService _randomService;

        public bool IsCollected { get; private set; }

        [Inject]
        private void Construct(IWalletService walletService, ISaveLoadService saveLoadService, IRandomService randomService)
        {
            _walletService = walletService;
            _saveLoadService = saveLoadService;
            _randomService = randomService;
        }

        public void Collect(Collector collector)
        {
            int coinsToRemove = _randomService.RangeInt(_minCoinAmountToRemove, _maxCoinAmountToRemove + 1);
            _walletService.RemoveCoins(coinsToRemove);
            _saveLoadService.SaveProgress();
            IsCollected = true;

            Destroy(gameObject);
        }
    }
}