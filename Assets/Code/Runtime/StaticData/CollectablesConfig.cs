using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectablesConfig", menuName = "Configs/CollectablesConfig")]
public class CollectablesConfig : ScriptableObject
{
    [Serializable]
    public class CollectableItem
    {
        public GameObject Prefab; // Префаб предмета
        [Range(1, 100)] public int Weight = 1; // Вага для ймовірності
    }

    [Header("Spawn Settings")]
    public float SpawnInterval = 2f; // Інтервал між спавнами
    public float RandomDeltaX = 2f; // Діапазон для випадкового X

    [Header("Collectables")]
    public List<CollectableItem> Items; // Список предметів і їхніх ваг
}