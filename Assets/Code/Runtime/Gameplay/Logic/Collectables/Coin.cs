using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Gameplay.View;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class Coin : MonoBehaviour, ICollecteble
    {
        [FormerlySerializedAs("moveFader")] [FormerlySerializedAs("_moveFadeDestroyer")] [SerializeField]
        private MoveFaderDestroy moveFaderDestroy;

        [SerializeField] private Rigidbody2D _rigidbody2D;

        [SerializeField] private Collider2D _collider2D;
        
        private string _collectSoundName = "Coin";

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

            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play(_collectSoundName);
            }
            
            Destroy(_rigidbody2D);
            _collider2D.enabled = false;
            moveFaderDestroy.Destroy();
        }
    }
}