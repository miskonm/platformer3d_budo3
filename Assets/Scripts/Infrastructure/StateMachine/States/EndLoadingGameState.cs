using Platformer.Game.Logger;
using Platformer.UI.Loading;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class EndLoadingGameState : BaseState
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IAppStateMachine _stateMachine;
        private readonly IGameLogger _gameLogger;

        public EndLoadingGameState(ILoadingScreen loadingScreen, IAppStateMachine stateMachine, IGameLogger gameLogger)
        {
            _loadingScreen = loadingScreen;
            _stateMachine = stateMachine;
            _gameLogger = gameLogger;
        }

        public override void Enter()
        {
            _gameLogger.Bootstrap();

            _stateMachine.Enter<GameState>();
        }

        public override void Exit()
        {
            _loadingScreen.Hide();
        }
    }
}