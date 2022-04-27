using Platformer.Infrastructure.SceneLoading;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class BootstrapState : BaseState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IAppStateMachine _stateMachine;

        public BootstrapState(ISceneLoader sceneLoader, IAppStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            // Prepare services
            _sceneLoader.LoadScene(SceneName.Menu);
            _stateMachine.Enter<MenuState>();
        }

        public override void Exit()
        {
            
        }
    }
}