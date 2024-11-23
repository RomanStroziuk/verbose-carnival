using System.Collections;
using Code.Runtime.Extensions;
using Code.Runtime.Infrastructure.Services;
using Code.Runtime.Infrastructure.Services.Random;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class CollectablesSpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnInterval = 2;

        [SerializeField] private GameObject _collectable;

        [SerializeField] private float _randomDeltaX = 2;

        private IRandomService _randomService;
        public float RandomDeltaX => _randomDeltaX;

        [Inject]
        private void Construct(IRandomService randomService)
        {
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
            Instantiate(_collectable, transform.position.SetX(GetRandomX()), Quaternion.identity, gameObject.transform);
        }

        private float GetRandomX()
        {
            return _randomService.Range(-_randomDeltaX, _randomDeltaX);
        }
    }
}