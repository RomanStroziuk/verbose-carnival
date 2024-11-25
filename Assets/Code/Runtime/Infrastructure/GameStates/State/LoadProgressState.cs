using Code.Runtime.Data;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.SaveLoad;
using Code.Runtime.Infrastructure.SaveLoadRegistry;
using Code.Runtime.Infrastructure.Services.Progress;
using Code.Runtime.Infrastructure.Services.SaveLoad;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    internal sealed class LoadProgressState : IEnterableState
    {
        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGameStateMachine _stateMachine;
        private readonly ISaveLoadRegistryService _saveLoadRegistryService;

        public LoadProgressState(IProgressService progressService, ISaveLoadService saveLoadService, IGameStateMachine stateMachine, ISaveLoadRegistryService saveLoadRegistryService)
        {
            _progressService = progressService;
            _saveLoadService = saveLoadService;
            _stateMachine = stateMachine;
            _saveLoadRegistryService = saveLoadRegistryService;
        }
        
            public void Enter()
        {
            PlayerProgress playerProgress = _saveLoadService.LoadProgress() ?? new PlayerProgress();
            _progressService.PlayerProgress = playerProgress;

            foreach (IReadProgress progressReader in _saveLoadRegistryService.ProgressReaders)
            {
                progressReader.Read(playerProgress);
            }
            
            _stateMachine.Enter<MenuState>();
        }
    }
}