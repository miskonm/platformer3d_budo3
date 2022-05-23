using Platformer.Infrastructure.Persistent.Data;

namespace Platformer.Infrastructure.SaveLoad
{
    public interface ISaveLoadService
    {
        PersistentData Load();
        void Save();
    }
}