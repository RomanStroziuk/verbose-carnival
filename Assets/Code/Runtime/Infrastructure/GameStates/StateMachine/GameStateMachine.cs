using Code.Runtime.Infrastructure.GameStates.Api;
using Code.Runtime.Infrastructure.GameStates.State;
using Code.Runtime.Infrastructure.GameStates.StateMachine;
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


        public void Enter<TState>()
            where TState : class, IEnterableState
        {
            IEnterableState state = GetState<TState>();
            
            if(_activeState is IExitableState activeState)
                activeState.Exit();
            
            state.Enter();
        }

        public  void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPlayloadedEnterableState<TPayload>
        {
            IPlayloadedEnterableState<TPayload> state = GetState<TState>();
            
            
            if(_activeState is IExitableState activeState)
                activeState?.Exit();
            
            Debug.Log($"GameStateMachine.Enter: Entered {typeof(TState).Name}");
            state.Enter(payload);
        }

        private TState GetState<TState>()
            where TState : class, IState =>
            _stateProvider.GetState<TState>();
       
        
       
    }
}