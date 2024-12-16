using Code.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic
{
    public class PlayerInputY : MonoBehaviour
    {
        [SerializeField] private MoverY _moverY;

        private IInputService _inputService;
        private int _currentJumpType = 0;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.IsJumping()) 
            {
                _moverY.TryJump(); 
            }
        }

        public void SetJumpType(int jumpAmount)
        {
            _currentJumpType = jumpAmount;
            _moverY.SetJumpType(jumpAmount); 
        }
    }
}