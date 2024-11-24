using UnityEngine;

namespace Code.Runtime.Infrastructure.Factories
{
    internal interface IGameFactory
    {
        GameObject CreatePlayer(Vector3 position);
        GameObject CreateHud(GameObject player);
    }
}