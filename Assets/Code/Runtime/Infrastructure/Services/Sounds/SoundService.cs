using System.Collections.Generic;
using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Infrastructure.Services.StaticData;
using DG.Tweening;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Sounds
{
    public class SoundService : ISoundService
    {
        private readonly IStaticDataService _staticDataService;
        private GameObject _audioRoot;
        private readonly Dictionary<SoundTypeId, AudioSource> _audioSources = new();

        public SoundService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            _audioRoot = new GameObject("SoundService");
            Object.DontDestroyOnLoad(_audioRoot);
        }

        public void Play(SoundTypeId soundType)
        {
            if (!TryGetAudioSource(soundType, out var audioSource))
            {
                var soundConfig = _staticDataService.GetSoundsConfig(soundType);
                if (soundConfig == null || soundConfig.Sound == null)
                {
                    Debug.LogWarning($"SoundConfig not found for soundType: {soundType}");
                    return;
                }

                audioSource = CreateAndAddAudioSource(soundType, soundConfig.Sound);
            }

            audioSource.Play();
        }

        public void Stop(SoundTypeId soundType)
        {
            if (TryGetAudioSource(soundType, out var audioSource) && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        public void FadeIn(SoundTypeId soundType, float targetVolume, float duration)
        {
            if (!TryGetAudioSource(soundType, out var audioSource))
            {
                var soundConfig = _staticDataService.GetSoundsConfig(soundType);
                if (soundConfig == null || soundConfig.Sound == null)
                {
                    Debug.LogWarning($"SoundConfig not found for soundType: {soundType}");
                    return;
                }

                audioSource = CreateAndAddAudioSource(soundType, soundConfig.Sound);
            }

            if (!audioSource.isPlaying)
            {
                audioSource.volume = 0f;
                audioSource.Play();
            }

            audioSource.DOFade(targetVolume, duration).SetEase(Ease.Linear);
        }

        public void FadeOut(SoundTypeId soundType, float duration)
        {
            if (TryGetAudioSource(soundType, out var audioSource) && audioSource.isPlaying)
            {
                audioSource.DOFade(0f, duration).SetEase(Ease.Linear).OnComplete(audioSource.Stop);
            }
        }

        private bool TryGetAudioSource(SoundTypeId soundType, out AudioSource audioSource)
        {
            return _audioSources.TryGetValue(soundType, out audioSource);
        }

        private AudioSource CreateAndAddAudioSource(SoundTypeId soundType, Sound sound)
        {
            var audioSource = _audioRoot.AddComponent<AudioSource>();
            audioSource.clip = sound.clip;
            audioSource.volume = sound.volume;
            audioSource.pitch = sound.pitch;
            audioSource.loop = sound.loop;
            audioSource.outputAudioMixerGroup = sound.mixer;

            _audioSources[soundType] = audioSource;
            return audioSource;
        }
    }
}