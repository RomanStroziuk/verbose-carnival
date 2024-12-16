using Code.Runtime.Gameplay.Logic.Sounds;
using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.Services.Input;
using Code.Runtime.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public class LevelState : IEnterableState, IExitableState
    {
        private const string PreviousMusicName = "StartMenu";
        private const string LevelMusicName = "ActiveGame";
        private const float FadeDuration = 2f;
        private const float MusicVolume = 0.1f;

        private readonly IInputService _inputService;
        private readonly IStaticDataService _staticDataService;

        public LevelState(IInputService inputService, IStaticDataService staticDataService)
        {
            _inputService = inputService;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _inputService.Enable();

            if (AudioManager.instance != null)
            {
                AudioManager.instance.FadeOut(PreviousMusicName, FadeDuration);
                AudioManager.instance.FadeIn(LevelMusicName, MusicVolume, FadeDuration);
            }

            Debug.Log($"Start health of player in config is {_staticDataService.PlayerConfig.StartHealth} ");
        }

        public void Exit()
        {
            _inputService.Disable();
        }
    }
}