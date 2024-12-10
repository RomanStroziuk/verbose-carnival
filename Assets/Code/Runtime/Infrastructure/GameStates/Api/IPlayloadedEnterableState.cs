namespace Code.Runtime.Infrastructure.GameStates.Api
{
    public interface IPlayloadedEnterableState<in TPayload> : IState
    {
        void Enter(TPayload payload);
    }
}