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
        private const float FadeDuration = 1f;
        private const float MusicVolume = 0.3f;
        private const SoundTypeId LevelMusic = SoundTypeId.GameplaySound;


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

            _soundService.FadeOutMusic(FadeDuration);
            _soundService.FadeInMusic(LevelMusic, MusicVolume, FadeDuration);
            Debug.Log($"Start health of player in config is {_staticDataService.PlayerConfig.StartHealth} ");
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}