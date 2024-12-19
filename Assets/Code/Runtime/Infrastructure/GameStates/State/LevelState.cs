using Code.Runtime.Data;
using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.Sounds;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public class LevelState : IEnterableState, IExitableState
    {
        private const float FadeDuration = 2f;
        private const float MusicVolume = 0.1f;

        private readonly IInputService _inputService;
        private readonly IStaticDataService _staticDataService;
        private ISoundService _soundService;

        public LevelState(IInputService inputService, IStaticDataService staticDataService, ISoundService soundService)
        {
            _inputService = inputService;
            _staticDataService = staticDataService;
            _soundService = soundService;
        }

        public void Enter()
        {
            _inputService.Enable();

            /*if (AudioManager._instance != null)
            {
                AudioManager._instance.FadeOut(PreviousMusicName, FadeDuration);
                AudioManager._instance.FadeIn(LevelMusicName, MusicVolume, FadeDuration);
            }*/
            
            _soundService.FadeOut(SoundTypeId.MenuSound, FadeDuration);
            _soundService.FadeIn(SoundTypeId.GameplaySound, MusicVolume, FadeDuration);
            Debug.Log($"Start health of player in config is {_staticDataService.PlayerConfig.StartHealth} ");
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}