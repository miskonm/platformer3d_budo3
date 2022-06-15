using Platformer.Infrastructure.Navigation;
using Platformer.Infrastructure.SceneLoading;
using Platformer.UI.Loading;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class StartLoadingGameState : BaseState
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IAppStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IUiService _uiService;

        public StartLoadingGameState(ILoadingScreen loadingScreen, IAppStateMachine stateMachine,
            ISceneLoader sceneLoader, IUiService uiService)
        {
            _loadingScreen = loadingScreen;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _uiService = uiService;
        }

        public override async void Enter()
        {
            _uiService.CloseAll();
            _loadingScreen.Show();

            await _sceneLoader.LoadSceneAsync(SceneName.Game);
            _stateMachine.Enter<EndLoadingGameState>();
        }

        public override void Exit()
        {
        }
    }
}