namespace Platformer.Infrastructure.StateMachine.States
{
    public interface IAppState
    {
        void Enter();
        void Exit();
    }
}