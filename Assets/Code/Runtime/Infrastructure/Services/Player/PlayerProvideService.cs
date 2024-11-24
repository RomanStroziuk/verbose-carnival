using Code.Runtime.Gameplay.Logic;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Player
{
    internal sealed class PlayerProvideService : IPlayerProvideService
    {
        public Wallet Wallet { get; private set; }
        
        public GameObject Player { get; private set; }

        public Health Health { get; set; }

        public void SetPlayer(GameObject player)
        {
            Player = player;
            Wallet = player.GetComponent<Wallet>();
            Health = player.GetComponent<Health>();
        }

        public void CleanUp()
        {
            Player = null;
            Wallet = null;
        }
    }
}