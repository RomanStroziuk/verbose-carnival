using System.Collections;
using System.Collections.Generic;
using Code.Runtime.Extensions;
using Code.Runtime.Infrastructure.Services;
using Code.Runtime.Infrastructure.Services.Random;
using TMPro.EditorUtilities;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 2;

        [SerializeField] private List<GameObject> _collectables;

        [SerializeField] private float _randomDeltaX = 2;

        private IRandomService _randomService;
        private IInstantiator _instantiator;
        public float RandomDeltaX => _randomDeltaX;

        [Inject]
        private void Construct(IRandomService randomService, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _randomService = randomService;
        }
        
        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnInterval);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            GameObject toSpawn = _randomService.ChooseFromList(_collectables);
            _instantiator.InstantiatePrefab(toSpawn, transform.position.SetX(GetRandomX()), Quaternion.identity, gameObject.transform);
        }

        private float GetRandomX()
        {
            return _randomService.Range(-_randomDeltaX, _randomDeltaX);
        }
    }
}