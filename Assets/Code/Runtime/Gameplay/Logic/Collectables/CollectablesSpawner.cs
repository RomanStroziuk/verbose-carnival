using System.Collections;
using System.Collections.Generic;
using Code.Runtime.Infrastructure.Services.Random;
using Code.Runtime.Infrastructure.Services.StaticData;
using Code.Runtime.StaticData;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Collectables
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [Header("Configuration")]
        private CollectablesConfig _configuration;

        private IRandomService _randomService;
        private IInstantiator _instantiator;

        public float RandomDeltaX => _configuration.RandomDeltaX;

        [Inject]
        private void Construct(IRandomService randomService, IInstantiator instantiator, IStaticDataService staticDataService)
        {
            _randomService = randomService;
            _instantiator = instantiator;
            _configuration = staticDataService.CollectablesConfig;
        }

        private IEnumerator Start()
        {
            while (_configuration == null)
            {
                yield return null; 
            }

            while (true)
            {
                yield return new WaitForSeconds(_configuration.SpawnInterval);
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
            if (_configuration.Items == null || _configuration.Items.Count == 0)
                return null;

            var weightedItems = new List<(GameObject, int)>();

            foreach (var item in _configuration.Items)
            {
                weightedItems.Add((item.Prefab, item.Rarity));
            }

            return _randomService.ChooseWeighted(weightedItems);
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float randomX = _randomService.Range(-_configuration.RandomDeltaX, _configuration.RandomDeltaX);
            return new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);
        }
    }
}
