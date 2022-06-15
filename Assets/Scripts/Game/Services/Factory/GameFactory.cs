using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Platformer.Game.Enemy;
using Platformer.Game.Logic;
using Platformer.Game.Services.Assets;
using Platformer.Game.Services.StaticData;
using Platformer.Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string Tag = nameof(GameFactory);

        private readonly IStaticDataService _staticDataService;
        private readonly DiContainer _diContainer;
        private readonly IAssetsService _assetsService;

        public List<ISaveLoadWriter> Writers { get; } = new List<ISaveLoadWriter>();
        public List<ISaveLoadReader> Readers { get; } = new List<ISaveLoadReader>();

        public GameFactory(IStaticDataService staticDataService, DiContainer diContainer, IAssetsService assetsService)
        {
            _staticDataService = staticDataService;
            _diContainer = diContainer;
            _assetsService = assetsService;
        }

        public void CreateEnemySpawner(EnemySpawnData spawnData)
        {
            string goName = $"{nameof(EnemySpawner)}_{spawnData.EnemyType}";
            EnemySpawner enemySpawner = _diContainer.InstantiateComponentOnNewGameObject<EnemySpawner>(goName);
            enemySpawner.transform.position = spawnData.Position;
            enemySpawner.EnemyType = spawnData.EnemyType;
            enemySpawner.Id = spawnData.Id;

            Register(enemySpawner.gameObject);
            // enemySpawner.Spawn(); // TODO: Remove
        }

        public async UniTask<GameObject> CreateEnemy(EnemyType enemyType, Vector3 at, string id)
        {
            EnemyData enemyData = _staticDataService.GetEnemyData(enemyType);
            if (enemyData == null)
            {
                Debug.LogError($"{Tag},{nameof(CreateEnemySpawner)}: No data for enemy '{enemyType}'");
                return null;
            }

            GameObject enemyGameObject = await _assetsService.Instantiate(enemyData.Reference);
            _diContainer.Inject(enemyGameObject);
            // GameObject enemyGameObject = _diContainer.InstantiatePrefab(gameObject);
            // EnemyHealth instantiatePrefabForComponent = _diContainer.InstantiatePrefabForComponent<EnemyHealth>(enemyData.Prefab, new[] {id});
            enemyGameObject.transform.position = at;
            enemyGameObject.GetComponent<IHealth>().Setup(enemyData.Hp, enemyData.Hp);
            Register(enemyGameObject);
            return enemyGameObject;
        }

        private void Register(GameObject go)
        {
            foreach (ISaveLoadWriter saveLoadWriter in go.GetComponentsInChildren<ISaveLoadWriter>())
                Writers.Add(saveLoadWriter);

            foreach (ISaveLoadReader saveLoadReader in go.GetComponentsInChildren<ISaveLoadReader>())
                Readers.Add(saveLoadReader);
        }

        public void Clean()
        {
            Writers.Clear();
            Readers.Clear();
        }
    }
}