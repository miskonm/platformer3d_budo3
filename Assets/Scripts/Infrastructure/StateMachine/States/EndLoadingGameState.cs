using Platformer.Game.Logger;
using Platformer.Game.Services.Factory;
using Platformer.Game.Services.StaticData;
using Platformer.Infrastructure.SceneLoading;
using Platformer.UI.Loading;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class EndLoadingGameState : BaseState
    {
        private readonly ILoadingScreen _loadingScreen;
        private readonly IAppStateMachine _stateMachine;
        private readonly IGameLogger _gameLogger;
        private readonly IStaticDataService _staticData;
        private readonly IGameFactory _gameFactory;

        public EndLoadingGameState(ILoadingScreen loadingScreen, IAppStateMachine stateMachine, IGameLogger gameLogger,
            IStaticDataService staticData, IGameFactory gameFactory)
        {
            _loadingScreen = loadingScreen;
            _stateMachine = stateMachine;
            _gameLogger = gameLogger;
            _staticData = staticData;
            _gameFactory = gameFactory;
        }

        public override void Enter()
        {
            _gameLogger.Bootstrap();
            _staticData.Load();

            LevelData levelData = _staticData.GetLevelData(GetLevelName());

            CreateEnemySpawners(levelData);

            _stateMachine.Enter<GameState>();
        }

        public override void Exit()
        {
            _loadingScreen.Hide();
        }

        private string GetLevelName() =>
            SceneName.Game;

        private void CreateEnemySpawners(LevelData levelData)
        {
            foreach (EnemySpawnData spawnData in levelData.EnemySpawnPoints)
                _gameFactory.CreateEnemySpawner(spawnData);
        }
    }
}