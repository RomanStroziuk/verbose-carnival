using System.ComponentModel;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Gameplay.View;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class Coin : MonoBehaviour, ICollecteble
    {
        [FormerlySerializedAs("moveFader")] [FormerlySerializedAs("_moveFadeDestroyer")] [SerializeField]
        private MoveFaderDestroy moveFaderDestroy;
        
        [SerializeField]
        private Rigidbody2D _rigidbody2D;
        
        [SerializeField]
        private Collider2D _collider2D;
        
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
            _saveLoadService.SaveProgress();
            IsCollected = true;
            
            Destroy(_rigidbody2D);
            _collider2D.enabled = false;
            moveFaderDestroy.Destroy();
        }
        
        
    }
}