using Code.Runtime.Data;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "StaticData/WindowConfig")]
    public class WindowConfig : ScriptableObject
    {
        public GameObject WindowPrefab;
        public WindowTypeId WindowTypeId;
    }
}