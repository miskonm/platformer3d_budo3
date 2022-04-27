using Platformer.Infrastructure.StateMachine.States;

namespace Platformer.Infrastructure.StateMachine
{
    public interface IDebugAppStateMachine
    {
        IAppState CurrentState { get; }
    }
}