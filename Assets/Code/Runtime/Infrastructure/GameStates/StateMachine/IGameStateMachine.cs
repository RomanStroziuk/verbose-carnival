namespace Code.Runtime.Infrastructure.GameStates
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IEnterableState;
    }
}