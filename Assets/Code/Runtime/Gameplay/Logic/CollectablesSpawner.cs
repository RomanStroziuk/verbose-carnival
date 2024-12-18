using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Code.Runtime.Infrastructure.Services.Random;

namespace Code.Runtime.Gameplay.Logic
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField] private CollectablesConfig _config; // Конфігурація предметів

        private IRandomService _randomService;
        private IInstantiator _instantiator;

        public float RandomDeltaX => _config.RandomDeltaX; // Додаємо публічний геттер для доступу до RandomDeltaX

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
                yield return new WaitForSeconds(_config.SpawnInterval); // Час між спавнами
                SpawnItem();
            }
        }

        private void SpawnItem()
        {
            GameObject toSpawn = GetRandomItem(); // Обираємо предмет з врахуванням ваги
            if (toSpawn == null) return;

            Vector3 spawnPosition = GetRandomSpawnPosition();
            _instantiator.InstantiatePrefab(toSpawn, spawnPosition, Quaternion.identity, transform);
        }

        private GameObject GetRandomItem()
        {
            if (_config.Items == null || _config.Items.Count == 0)
                return null;

            int totalWeight = 0;
            foreach (var item in _config.Items)
                totalWeight += item.Weight;

            int randomValue = (int)_randomService.Range(0, totalWeight); // Приведення float до int
            int currentWeight = 0;

            foreach (var item in _config.Items)
            {
                currentWeight += item.Weight;
                if (randomValue < currentWeight)
                    return item.Prefab;
            }

            return null;
        }

        private Vector3 GetRandomSpawnPosition()
        {
            float randomX = _randomService.Range(-_config.RandomDeltaX, _config.RandomDeltaX);
            return new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);
        }
    }
}
