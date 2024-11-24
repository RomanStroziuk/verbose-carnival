using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Runtime.Gameplay.View.UI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        private IGameStateMachine _gameStateMachine;


        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        private void Awake()
        {
            _button.onClick.AddListener(OnButtonClicked);
        }
        
        private void OnDestroy() =>
        _button.onClick.RemoveListener(OnButtonClicked);

        private void OnButtonClicked()
        {
            _gameStateMachine.Enter<LoadLevelState, string>("Level");
        }
    }
}