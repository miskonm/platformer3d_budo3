using System;

namespace Platformer.Infrastructure.Persistent.Data
{
    [Serializable]
    public class PersistentData
    {
        public PersistentLevelData LevelData;

        public PersistentData()
        {
            LevelData = new PersistentLevelData();
        }
    }
}