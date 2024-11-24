using Code.Runtime.Gameplay.View.UI;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    
    [CreateAssetMenu(fileName = "HudConfig", menuName = "StaticData/HudConfig")]
    public sealed class HudConfig : ScriptableObject
    {
        public GameObject hudPrefab;
    }
} 