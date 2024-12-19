using Code.Runtime.Data;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Sounds
{
    public interface ISoundService
    {
        void StopEffect();
        void FadeInMusic(SoundTypeId soundType, float targetVolume, float duration);
        void FadeOutMusic(float duration);
        void Initialize();
        void PlayEffect(SoundTypeId soundType);
    }
}