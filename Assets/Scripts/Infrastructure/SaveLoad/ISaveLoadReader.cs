using Platformer.Infrastructure.Persistent.Data;

namespace Platformer.Infrastructure.SaveLoad
{
    public interface ISaveLoadReader
    {
        void Load(PersistentData persistentData);
    }
}