using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Game.Services.StaticData
{
    [CreateAssetMenu(fileName = Tag, menuName = "StaticData/Level")]
    public class LevelData : ScriptableObject
    {
        private const string Tag = nameof(LevelData);

        public string LevelName;
        public List<EnemySpawnData> EnemySpawnPoints;
    }
}