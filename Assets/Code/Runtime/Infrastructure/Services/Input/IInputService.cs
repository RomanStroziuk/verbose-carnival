namespace Code.Runtime.Infrastructure.Services.Input
{
    public interface IInputService
    {
        float GetMovement();
        bool IsJumping();
        void Enable();
        void Disable();
    }
}