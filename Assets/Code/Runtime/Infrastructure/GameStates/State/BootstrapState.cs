using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.SaveLoadRegistry;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.Shop;
using Code.Runtime.Infrastructure.Services.StaticData;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public sealed class BootstrapState : IEnterableState
    {
        private const string BootstrapSceneName = "BootstrapScene";

        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly IWalletService _walletService;
        private readonly ISaveLoadRegistryService _saveLoadRegistryService;
        private readonly IShopService _shopService;
        private readonly IPlayerInventoryService _playerInventoryService;
        
        public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader,
            IStaticDataService staticDataService,
            IWalletService walletService, ISaveLoadRegistryService saveLoadRegistryService, IShopService shopService,
            IPlayerInventoryService playerInventoryService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadRegistryService = saveLoadRegistryService;
            _shopService = shopService;
            _playerInventoryService = playerInventoryService;
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(BootstrapSceneName);
            _staticDataService.LoadAll();

            RegisterProgressReadersWriters();

            _stateMachine.Enter<LoadProgressState>();
        }

        private void RegisterProgressReadersWriters()
        {
            _saveLoadRegistryService.RegisterAsProgressReader(_walletService);
            _saveLoadRegistryService.RegisterAsProgressWriter(_walletService);
            _saveLoadRegistryService.RegisterAsProgressReader(_shopService);
            _saveLoadRegistryService.RegisterAsProgressWriter(_shopService);
            _saveLoadRegistryService.RegisterAsProgressReader(_playerInventoryService);
            _saveLoadRegistryService.RegisterAsProgressWriter(_playerInventoryService);
        }
    }
}