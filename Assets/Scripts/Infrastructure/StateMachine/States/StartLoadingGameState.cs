using System.Collections;
using Platformer.Infrastructure.Coroutines;
using Platformer.Infrastructure.SceneLoading;
using Platformer.UI.Loading;
using UnityEngine;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class StartLoadingGameState : BaseState
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IAppStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;

        public StartLoadingGameState(ILoadingScreen loadingScreen, IAppStateMachine stateMachine,
            ISceneLoader sceneLoader, ICoroutineRunner coroutineRunner)
        {
            _loadingScreen = loadingScreen;
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _coroutineRunner = coroutineRunner;
        }

        public override void Enter()
        {
            _loadingScreen.Show();

            _coroutineRunner.StartCoroutine(EnterWithDelay());
        }

        public override void Exit()
        {
        }

        private IEnumerator EnterWithDelay()
        {
            _sceneLoader.LoadScene(SceneName.Game);

            yield return new WaitForSeconds(1f);
            _stateMachine.Enter<EndLoadingGameState>();
        }
    }
}