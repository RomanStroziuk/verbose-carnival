using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Runtime.Gameplay.Logic.Sounds
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager _instance;

        public Sound[] sounds;

        void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }

            foreach (Sound s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;
                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }

        public void Play(string sound)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            s.source.Play();
        }

        public void Stop(string sound)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            s.source.Stop();
        }
        
        public void FadeIn(string sound, float targetVolume, float duration)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null)
            {
                Debug.LogWarning($"Sound '{sound}' not found!");
                return;
            }

            s.source.volume = 0f;
            s.source.Play();
            s.source.DOFade(targetVolume, duration).SetEase(Ease.Linear);
        }

        public void FadeOut(string sound, float duration)
        {
            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null)
            {
                Debug.LogWarning($"Sound '{sound}' not found!");
                return;
            }

            s.source.DOFade(0f, duration).SetEase(Ease.Linear).OnComplete(() =>
            {
                s.source.Stop();
            });
        }
    }
}