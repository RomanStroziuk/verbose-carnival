namespace Code.Runtime.Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        

        private const string AxisHorizontal = "Horizontal";
        private bool _enabled = true;

        public void Enable()
        {
            _enabled = true;
        }
        
        public void Disable()
        {
            _enabled = false;
        }

        public float GetMovement() =>
            _enabled
                ? UnityEngine.Input.GetAxis(AxisHorizontal)
                : 0;

    }
}