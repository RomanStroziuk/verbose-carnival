using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using UnityEngine;

namespace Code.Runtime.StaticData
{
    [CreateAssetMenu(fileName = "SoundConfig", menuName = "StaticData/SoundConfig")]
    public class SoundConfig : ScriptableObject
    {
        public SoundTypeId SoundTypeId;
        public Sound Sound;
    }
}