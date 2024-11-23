using UnityEngine;

namespace Code.Runtime.Infrastructure.GameStates
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly IStateProvider _stateProvider;
        private IState _activeState;

        public GameStateMachine(IStateProvider stateProvider)
        {
            _stateProvider = stateProvider;
        }

        public  void Enter<TState>()
            where TState : class, IEnterableState
        {
            IEnterableState state = GetState<TState>();
            
            
            if(_activeState is IExitableState activeState)
                activeState?.Exit();
            
            Debug.Log($"GameStateMachine.Enter: Entered {typeof(TState).Name}");
            state.Enter();
        }

        private TState GetState<TState>()
            where TState : class, IEnterableState =>
            _stateProvider.GetState<TState>();
       
        
       
    }
}