using Code.Runtime.Gameplay.Logic;
using Code.Runtime.Gameplay.View.UI;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Factories
{
     internal sealed class GameFactory : IGameFactory
     {
        private readonly IStaticDataService _staticDataService;

        public GameFactory(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public GameObject CreatePlayer(Vector3 position)
        {
           return Object.Instantiate(_staticDataService.PlayerConfig.playerPrefab, position, Quaternion.identity);
        }

        public GameObject CreateHud(GameObject player)
        {
            Wallet wallet = player.GetComponent<Wallet>();
            Health health = player.GetComponent<Health>();
            Hud hud = Object.Instantiate(_staticDataService.HUDConfig.hudPrefab);
                hud.SetUp(wallet, health);
                return hud.gameObject;
        }
    }
}