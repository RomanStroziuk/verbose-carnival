using Code.Runtime.Infrastructure.Services.Scene;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public sealed class BootstrapState : IEnterableState
    {
        
        private const string LevelName = "Level";
        private const string BootstrapSceneName = "BootstrapScene";

        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;


        public BootstrapState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        public void Enter()
        {
            _sceneLoader.LoadScene(BootstrapSceneName);
            
                //initialize
                
                
            _sceneLoader.LoadScene(LevelName);
            _stateMachine.Enter<LevelState>();

        }
        
        
    }
}