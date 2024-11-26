using Code.Runtime.Data;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "HatConfig", menuName = "StaticData/HatConfig")]
    public class HatConfig : ScriptableObject
    {
        public HatTypeId HatTypeId;
        public string Name;
        public Sprite Sprite;
        public int Price;
    }
}