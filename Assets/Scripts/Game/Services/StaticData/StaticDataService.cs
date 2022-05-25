using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Platformer.Game.Enemy;
using UnityEngine;

namespace Platformer.Game.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string LevelsPath = "StaticData/Level";
        private const string EnemiesPath = "StaticData/Enemies";

        private Dictionary<string, LevelData> _levels;
        private Dictionary<EnemyType, EnemyData> _enemies;

        public void Load()
        {
            _levels = Resources.LoadAll<LevelData>(LevelsPath)
                .ToDictionary(x => x.LevelName, x => x);
            
            _enemies = Resources.LoadAll<EnemyData>(EnemiesPath)
                .ToDictionary(x => x.EnemyType, x => x);
        }

        public LevelData GetLevelData(string levelName) =>
            _levels.TryGetValue(levelName, out LevelData levelData) ? levelData : null;

        public EnemyData GetEnemyData(EnemyType enemyType) =>
            _enemies.TryGetValue(enemyType, out EnemyData enemyData) ? enemyData : null;
    }
}