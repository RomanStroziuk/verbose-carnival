using Code.Runtime.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Runtime.Gameplay.Logic.Movement
{
    public class PlayerInputX : MonoBehaviour
    {
        [SerializeField] private MoverX _mover;
        private IInputService _inputService;
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        private void Update()
        {
            float movement = _inputService.GetMovement();
            _mover.Move(movement);
        }
    }
}