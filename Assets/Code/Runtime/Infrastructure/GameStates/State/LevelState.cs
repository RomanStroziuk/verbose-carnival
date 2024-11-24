using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.Player;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public class LevelState : IEnterableState , IExitableState 
    {
        
        private readonly IInputService _inputService;
        private readonly IStaticDataService _staticDataService;
        private readonly IPlayerProvideService _playerProvider;

        public LevelState(IInputService inputService,
            IStaticDataService staticDataService,
            IPlayerProvideService playerProvideService)
        {
            _inputService = inputService;
            _staticDataService = staticDataService;
            _playerProvider = playerProvideService;
        }
        public void Enter()
        {
            _inputService.Enable();
            Debug.Log($"Start health of player in config is {_staticDataService.PlayerConfig.StartHealth} ");

        }
        public void Exit()
        {
            _inputService.Disable();
            _playerProvider.CleanUp();
        }
        
    }
}