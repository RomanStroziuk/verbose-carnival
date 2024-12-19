using Code.Runtime.Data;
using Code.Runtime.Infrastructure.Services.StaticData;
using DG.Tweening;
using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Sounds
{
    public class SoundService : ISoundService
    {
        private readonly IStaticDataService _staticDataService;
        private GameObject _audioRoot;

        private AudioSource _musicAudioSource; 
        private AudioSource _effectAudioSource;

        public SoundService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Initialize()
        {
            _audioRoot = new GameObject("SoundService");
            Object.DontDestroyOnLoad(_audioRoot);

            _musicAudioSource = _audioRoot.AddComponent<AudioSource>();
            _musicAudioSource.loop = true;

            _effectAudioSource = _audioRoot.AddComponent<AudioSource>();
        }

        public void FadeInMusic(SoundTypeId soundType, float targetVolume, float duration)
        {
            var soundConfig = _staticDataService.GetSoundsConfig(soundType);
            if (soundConfig == null || soundConfig.Sound == null)
            {
                Debug.LogWarning($"Music config not found for soundType: {soundType}");
                return;
            }

            _musicAudioSource.clip = soundConfig.Sound.clip;
            _musicAudioSource.volume = 0f;
            _musicAudioSource.Play();

            _musicAudioSource.DOFade(targetVolume, duration).SetEase(Ease.Linear);
        }

        public void FadeOutMusic(float duration)
        {
            if (_musicAudioSource.isPlaying)
            {
                _musicAudioSource.DOFade(0f, duration).SetEase(Ease.Linear);
            }
        }

        public void PlayEffect(SoundTypeId soundType)
        {
            var soundConfig = _staticDataService.GetSoundsConfig(soundType);
            if (soundConfig == null || soundConfig.Sound == null)
            {
                Debug.LogWarning($"Effect config not found for soundType: {soundType}");
                return;
            }

            _effectAudioSource.PlayOneShot(soundConfig.Sound.clip, soundConfig.Sound.volume);
        }

        public void StopEffect()
        {
            if (_effectAudioSource.isPlaying)
            {
                _effectAudioSource.Stop();
            }
        }
    }
}
