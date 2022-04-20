using Platformer.Infrastructure.StateMachine.States;

namespace Platformer.Infrastructure.StateMachine
{
    public interface IAppStateMachine
    {
        void Enter<TState>() where TState : IAppState;
    }
}