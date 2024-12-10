namespace Code.Runtime.Infrastructure.Services.Input
{
    public interface IInputService
    {
        void Enable();
        
        void Disable();
        
        float GetMovement();
        
        bool GetJump();
    }
}