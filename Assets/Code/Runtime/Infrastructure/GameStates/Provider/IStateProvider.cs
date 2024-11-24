namespace Code.Runtime.Infrastructure.GameStates
{
    public interface IStateProvider 
    {
        TState GetState<TState>() 
            where TState : class, IState;
    }
}