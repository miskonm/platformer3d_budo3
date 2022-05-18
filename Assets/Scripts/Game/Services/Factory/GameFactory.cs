using Platformer.Game.Enemy;
using Platformer.Game.Logic;
using Platformer.Game.Services.StaticData;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string Tag = nameof(GameFactory);
        
        private readonly IStaticDataService _staticDataService;
        private readonly DiContainer _diContainer;

        public GameFactory(IStaticDataService staticDataService, DiContainer diContainer)
        {
            _staticDataService = staticDataService;
            _diContainer = diContainer;
        }

        public void CreateEnemySpawner(EnemySpawnData spawnData)
        {
            string goName = $"{nameof(EnemySpawner)}_{spawnData.EnemyType}";
            EnemySpawner enemySpawner = _diContainer.InstantiateComponentOnNewGameObject<EnemySpawner>(goName);
            enemySpawner.transform.position = spawnData.Position;
            enemySpawner.EnemyType = spawnData.EnemyType;

            enemySpawner.Spawn(); // TODO: Remove
        }

        public void CreateEnemy(EnemyType enemyType, Vector3 at)
        {
            EnemyData enemyData = _staticDataService.GetEnemyData(enemyType);
            if (enemyData == null)
            {
                Debug.LogError($"{Tag},{nameof(CreateEnemySpawner)}: No data for enemy '{enemyType}'");
                return;
            }

            GameObject enemyGameObject = _diContainer.InstantiatePrefab(enemyData.Prefab);
            enemyGameObject.transform.position = at;
            enemyGameObject.GetComponent<IHealth>().Setup(enemyData.Hp, enemyData.Hp);
        }
    }
}