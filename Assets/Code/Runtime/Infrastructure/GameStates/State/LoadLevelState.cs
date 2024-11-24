using Code.Runtime.Gameplay.Markers;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.Services.Player;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    internal sealed class LoadLevelState : IPlayloadedEnterableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IStaticDataService _staticDataService;
        private readonly IGameStateMachine _stateMachine;
        private readonly IPlayerProvideService _playerProvideService;

        public LoadLevelState(ISceneLoader sceneLoader,
            IStaticDataService staticDataService,
            IGameStateMachine gameStateMachine,  
            IPlayerProvideService playerProvideService)
        {
            _sceneLoader = sceneLoader;
            _staticDataService = staticDataService;
            _stateMachine = gameStateMachine;
            _playerProvideService = playerProvideService;
        } 


        public void Enter(string payload)
        {
            _sceneLoader.LoadScene(payload);
            SpawnPlayer();
            
            _stateMachine.Enter<LevelState>();
        }

        private void SpawnPlayer()
        {
            Vector3 playerSpawnPosition = Object.FindObjectOfType<PlayerSpawnPoint>().transform.position;
            GameObject player = Object.Instantiate(_staticDataService.PlayerConfig.playerPrefab, playerSpawnPosition, Quaternion.identity);
            _playerProvideService.SetPlayer(player);
        }
    }
}