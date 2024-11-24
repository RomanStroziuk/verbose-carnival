using Zenject;

namespace Code.Runtime.Infrastructure.GameStates
{
    public class StateProvider : IStateProvider
    {
        private readonly DiContainer _container;

        public StateProvider(DiContainer container)
        {
            _container = container;
        }
        
        public TState GetState<TState>()
           where TState : class, IState =>
            _container.Resolve<TState>();
    }
}