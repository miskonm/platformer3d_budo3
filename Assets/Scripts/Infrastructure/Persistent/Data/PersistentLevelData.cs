using System;
using System.Collections.Generic;

namespace Platformer.Infrastructure.Persistent.Data
{
    [Serializable]
    public class PersistentLevelData
    {
        public List<string> KilledEnemies = new List<string>();
    }
}