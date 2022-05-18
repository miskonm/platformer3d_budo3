using Platformer.Game.Enemy;
using Platformer.Game.Services.StaticData;
using UnityEngine;

namespace Platformer.Game.Services.Factory
{
    public interface IGameFactory
    {
        void CreateEnemySpawner(EnemySpawnData spawnData);
        void CreateEnemy(EnemyType enemyType, Vector3 at);
    }
}