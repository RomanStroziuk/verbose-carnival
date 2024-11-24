using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.StaticData;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public sealed class BootstrapState : IEnterableState
    {
        
        private const string LevelName = "Level";
        private const string BootstrapSceneName = "BootstrapScene";

        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;


        public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader, IStaticDataService staticDataService)
        {
            _stateMachine = stateMachine;
            _staticDataService = staticDataService;
        }
        public void Enter()
        {
            _sceneLoader.LoadScene(BootstrapSceneName);
            _staticDataService.LoadAll();
                
            _stateMachine.Enter<MenuState>();

        }
        
        
    }
}