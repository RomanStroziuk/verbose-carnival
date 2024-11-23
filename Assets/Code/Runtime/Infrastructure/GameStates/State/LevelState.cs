using Code.Runtime.Infrastructure.Services.Input;

namespace Code.Runtime.Infrastructure.GameStates.State
{
    public class LevelState : IEnterableState , IExitableState 
    {
        
        private readonly IInputService _inputService;

        public LevelState(IInputService inputService)
        {
            _inputService = inputService;
        }
        public void Enter()
        {
            _inputService.Enable();
        }
        public void Exit()
        {
            _inputService.Disable();
        }
        
    }
}