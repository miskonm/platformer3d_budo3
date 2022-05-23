using Platformer.Infrastructure.Persistent.Data;

namespace Platformer.Infrastructure.SaveLoad
{
    public interface ISaveLoadWriter : ISaveLoadReader
    {
        void Save(PersistentData persistentData);
    }
}