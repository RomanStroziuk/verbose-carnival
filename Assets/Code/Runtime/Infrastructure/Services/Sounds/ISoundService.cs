using Code.Runtime.Data;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Sounds
{
    public interface ISoundService
    {
        void Play(SoundTypeId soundType);
        void Stop(SoundTypeId soundType);
        void FadeIn(SoundTypeId soundType, float targetVolume, float duration);
        void FadeOut(SoundTypeId soundType, float duration);
        void Initialize();
    }
}