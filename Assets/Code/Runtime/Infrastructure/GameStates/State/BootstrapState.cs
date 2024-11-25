using Code.Runtime.Gameplay.Service.Wallet;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.SaveLoadRegistry;
using Code.Runtime.Infrastructure.Services.Scene;
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


        public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService, IWalletService walletService, ISaveLoadRegistryService saveLoadRegistryService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _walletService = walletService;
            _saveLoadRegistryService = saveLoadRegistryService;
        }
        public void Enter()
        {
            _sceneLoader.LoadScene(BootstrapSceneName);
            _staticDataService.LoadAll();
                
            _saveLoadRegistryService.RegisterAsProgressReader(_walletService);
            _saveLoadRegistryService.RegisterAsProgressWriter(_walletService);

            _stateMachine.Enter<LoadProgressState>();

        }
        
        
    }
}