using System.Collections;
using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private CollectablesConfig configuration; 

        private IRandomService _randomService;
        private IInstantiator _instantiator;

        public float RandomDeltaX => configuration.RandomDeltaX;

        [Inject]
        private void Construct(IRandomService randomService, IInstantiator instantiator)
        {
            _randomService = randomService;
            _instantiator = instantiator;
        }

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(configuration.SpawnInterval); 
                SpawnItem();
            }
        }
        
        private void SpawnItem()
        {
            GameObject toSpawn = GetRandomItem();
            if (toSpawn == null) return;

            Vector3 spawnPosition = GetRandomSpawnPosition();
            _instantiator.InstantiatePrefab(toSpawn, spawnPosition, Quaternion.identity, transform);
        }

        private GameObject GetRandomItem()
        {
            if (configuration.Items == null || configuration.Items.Count == 0)
                return null;

            int totalWeight = 0;
            foreach (var item in configuration.Items)
                totalWeight += item.Rarity;

            int randomValue = _randomService.RangeInt(0, totalWeight);
            int currentWeight = 0;

            foreach (var item in configuration.Items)
            {
                currentWeight += item.Rarity;
                if (randomValue < currentWeight)
                    return item.Prefab;
            }

            return null;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float randomX = _randomService.Range(-configuration.RandomDeltaX, configuration.RandomDeltaX);
            return new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);
        }
    }
}
