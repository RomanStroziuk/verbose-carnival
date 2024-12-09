using Code.Runtime.Data;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "JumpConfig", menuName = "StaticData/JumpConfig")]
    public class JumpConfig : ScriptableObject
    {
        public JumpTypeId JumpTypeId;
        public Sprite Sprite;
    }
}   