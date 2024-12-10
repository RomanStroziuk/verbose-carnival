using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        private const string JumpButton = "Jump";
        private bool _enabled;

        public void Enable()
        {
            _enabled = true;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public float GetMovement() =>
            _enabled ? UnityEngine.Input.GetAxis("Horizontal") : 0;

        public bool GetJump() =>
            _enabled && UnityEngine.Input.GetButtonDown(JumpButton);
    }
}