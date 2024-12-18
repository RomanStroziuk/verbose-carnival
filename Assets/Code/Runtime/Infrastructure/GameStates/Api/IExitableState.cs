namespace Code.Runtime.Infrastructure.GameStates.Api
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}