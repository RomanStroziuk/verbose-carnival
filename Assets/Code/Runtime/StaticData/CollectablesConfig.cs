using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "CollectablesConfig", menuName = "Configs/CollectablesConfig")]
    public class CollectablesConfig : ScriptableObject
    {
        [Serializable]
        public class CollectableItem
        {
            public GameObject Prefab;
            [Range(1, 100)] public int Rarity = 1;
        }

        [Header("Spawn Settings")] public float SpawnInterval = 2f;
        public float RandomDeltaX = 2f;

        [Header("Collectables")] public List<CollectableItem> Items;
    }
}