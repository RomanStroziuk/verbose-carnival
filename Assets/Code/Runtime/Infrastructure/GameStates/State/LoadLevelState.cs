using Code.Runtime.Gameplay.Markers;
using Code.Runtime.Infrastructure.Factories;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    internal sealed class LoadLevelState : IPlayloadedEnterableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(ISceneLoader sceneLoader,
            IStaticDataService staticDataService,
            IGameStateMachine gameStateMachine,
            IGameFactory gameFactory)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        } 


        public void Enter(string payload)
        {
            _sceneLoader.LoadScene(payload);
            
            GameObject spawnPlayer = SpawnPlayer();
            _gameFactory.CreateHud(spawnPlayer);

            
            _stateMachine.Enter<LevelState>();
        }

        private GameObject SpawnPlayer()
        {
            Vector3 playerSpawnPosition = Object.FindObjectOfType<PlayerSpawnPoint>().transform.position;
           return _gameFactory.CreatePlayer(playerSpawnPosition);
        }
    }
}