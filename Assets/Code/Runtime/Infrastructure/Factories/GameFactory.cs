using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.View;
using Code.Runtime.Gameplay.View.UI;
using Code.Runtime.Infrastructure.Services.PlayerInventory;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Infrastructure.Factories
{
     internal sealed class GameFactory : IGameFactory
     {
        private readonly IStaticDataService _staticDataService;
        private readonly IInstantiator _instantiator;
        private readonly IPlayerInventoryService _playerInventoryService;


        public GameFactory(IStaticDataService staticDataService, IInstantiator instantiator, IPlayerInventoryService playerInventoryService)
        {
            _staticDataService = staticDataService;
            _instantiator = instantiator;
            _playerInventoryService = playerInventoryService;
        }

        public GameObject CreatePlayer(Vector3 position)
        {
           GameObject player = _instantiator.InstantiatePrefab(_staticDataService.PlayerConfig.playerPrefab, position, Quaternion.identity, null);
           
           player.GetComponent<Health>().CurrentHealth = _staticDataService.PlayerConfig.StartHealth;

           player.GetComponentInChildren<Hat>().SetHat(_playerInventoryService.SelectedHat);
               
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