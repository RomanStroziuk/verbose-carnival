namespace Code.Runtime.Infrastructure.GameStates
{
    public interface IExitableState : IState
    {
        void Exit();
    }
}