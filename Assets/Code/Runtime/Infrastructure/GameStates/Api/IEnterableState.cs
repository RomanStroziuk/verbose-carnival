namespace Code.Runtime.Infrastructure.GameStates.Api
{
    public interface IEnterableState : IState
    {
        void Enter();
    }
}