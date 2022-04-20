using Platformer.Infrastructure.StateMachine.States;
using Zenject;

namespace Platformer.Infrastructure.StateMachine
{
    public interface IAppStateFactory
    {
        void SetContainer(DiContainer container);
        IAppState Create<TState>() where TState : IAppState;
    }
}