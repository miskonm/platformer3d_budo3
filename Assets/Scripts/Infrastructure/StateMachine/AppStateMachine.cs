using Platformer.Infrastructure.StateMachine.States;

namespace Platformer.Infrastructure.StateMachine
{
    public class AppStateMachine : IAppStateMachine, IDebugAppStateMachine
    {
        private readonly IAppStateFactory _appStateFactory;
        
        private IAppState _currentState;

        public IAppState CurrentState => _currentState;

        public AppStateMachine(IAppStateFactory appStateFactory)
        {
            _appStateFactory = appStateFactory;
        }

        public void Enter<TState>() where TState : IAppState
        {
            _currentState?.Exit();
            _currentState = _appStateFactory.Create<TState>();
            _currentState.Enter();
        }

      
    }
}