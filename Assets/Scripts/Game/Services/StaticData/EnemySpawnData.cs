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
        public string Id;

        public EnemySpawnData(EnemyType enemyType, Vector3 position, string id)
        {
            EnemyType = enemyType;
            Position = position;
            Id = id;
        }
    }
}