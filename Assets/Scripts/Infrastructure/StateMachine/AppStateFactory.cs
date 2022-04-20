using Platformer.Infrastructure.StateMachine.States;
using Zenject;

namespace Platformer.Infrastructure.StateMachine
{
    public class AppStateFactory : IAppStateFactory
    {
        private DiContainer _diContainer;

        public void SetContainer(DiContainer container) =>
            _diContainer = container;

        public IAppState Create<TState>() where TState : IAppState =>
            _diContainer.Instantiate<TState>();
    }
}