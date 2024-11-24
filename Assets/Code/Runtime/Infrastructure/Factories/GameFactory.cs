using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.View.UI;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Infrastructure.Factories
{
     internal sealed class GameFactory : IGameFactory
     {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;


        public GameFactory(IStaticDataService staticDataService, IInstantiator instantiator)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
        }

        public GameObject CreatePlayer(Vector3 position)
        {
           GameObject player = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.playerPrefab, position, Quaternion.identity, null);
           
           player.GetComponent<Health>().CurrentHealth = _staticDataService.PlayerConfig.StartHealth;
               
           return player;
        }

        public GameObject CreateHud(GameObject player)
        {
            Health health = player.GetComponent<Health>();
            Hud hud = _instantiator.InstantiatePrefabForComponent<Hud>(_staticDataService.HUDConfig.hudPrefab);
                hud.SetUp(health);
                return hud.gameObject;
        }
    }
}