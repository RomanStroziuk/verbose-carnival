namespace Code.Runtime.Infrastructure.Services.Input
{
    internal interface IInputService
    {
        
        void Enable();
        
        void Disable();
        
        float GetMovement();
    }
}