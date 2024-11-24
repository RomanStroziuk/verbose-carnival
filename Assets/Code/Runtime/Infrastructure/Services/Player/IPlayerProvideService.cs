using Code.Runtime.Gameplay.Logic;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Player
{
    public interface IPlayerProvideService
    {
        
        Wallet Wallet { get; }
       GameObject Player { get; }
       
        Health Health { get; set; }
       void SetPlayer(GameObject player);

       void CleanUp();


    }
}