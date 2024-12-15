using Code.Runtime.Infrastructure.GameStates.Api;

namespace Code.Runtime.Infrastructure.GameStates.Provider
{
    public interface IStateProvider 
    {
        TState GetState<TState>() 
            where TState : class, IState;
    }
}