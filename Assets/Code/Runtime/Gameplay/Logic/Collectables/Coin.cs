using Code.Runtime.Data;
using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Gameplay.View;
using Code.Runtime.Infrastructure.Services.SaveLoad;
using Code.Runtime.Infrastructure.Services.Sounds;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class Coin : MonoBehaviour, ICollecteble
    {
        [SerializeField] private MoveFaderDestroy moveFaderDestroy;

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;

        private IWalletService _walletService;
        private ISaveLoadService _saveLoadService;
        private ISoundService _soundService;
        
        private const SoundTypeId Effect = SoundTypeId.CoinSound;

        public bool IsCollected { get; private set; }

        [Inject]
        private void Construct(IWalletService walletService, ISaveLoadService saveLoadService,
            ISoundService soundService)
        {
            _saveLoadService = saveLoadService;
            _walletService = walletService;
            _soundService = soundService;
        }

        public void Collect(Collector collector)
        {
            _walletService.AddCoin();
            _saveLoadService.SaveProgress();
            IsCollected = true;

            _soundService.PlayEffect(Effect);

            Destroy(_rigidbody2D);
            _collider2D.enabled = false;
            moveFaderDestroy.Destroy();
        }
    }
}