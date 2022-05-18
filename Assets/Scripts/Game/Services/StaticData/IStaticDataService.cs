using Platformer.Game.Enemy;

namespace Platformer.Game.Services.StaticData
{
    public interface IStaticDataService
    {
        void Load();
        LevelData GetLevelData(string levelName);
        EnemyData GetEnemyData(EnemyType enemyType);
    }
}