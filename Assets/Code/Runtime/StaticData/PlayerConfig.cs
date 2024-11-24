using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObjects/PlayerConfig")]

    public sealed class PlayerConfig : ScriptableObject
    {
        public GameObject playerPrefab;
        public float StartHealth;
    }
} 