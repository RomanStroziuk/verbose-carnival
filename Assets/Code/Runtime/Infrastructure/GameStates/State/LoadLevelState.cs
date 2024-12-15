using Code.Runtime.Infrastructure.Factories;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Code.Runtime.Infrastructure.Services.Scene;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    internal sealed class LoadLevelState : IPlayloadedEnterableState<string>
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IGameStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(ISceneLoader sceneLoader,
            IStaticDataService staticDataService,
            IGameStateMachine gameStateMachine,
            IGameFactory gameFactory, IStaticDataService staticData)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _staticData = staticData;
        }

        public void Enter(string payload)
        {
            _sceneLoader.LoadScene(payload);

            LevelData levelData = _staticData.GetLevelData(payload);
            GameObject spawnPlayer = _gameFactory.CreatePlayer(levelData.PlayerPosition);
            _gameFactory.CreateHud(spawnPlayer);

            _stateMachine.Enter<LevelState>();
        }
        
    }
}