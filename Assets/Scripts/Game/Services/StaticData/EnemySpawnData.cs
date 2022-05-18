using System;
using Platformer.Game.Enemy;
using UnityEngine;

namespace Platformer.Game.Services.StaticData
{
    [Serializable]
    public class EnemySpawnData
    {
        public EnemyType EnemyType;
        public Vector3 Position;

        public EnemySpawnData(EnemyType enemyType, Vector3 position)
        {
            EnemyType = enemyType;
            Position = position;
        }
    }
}