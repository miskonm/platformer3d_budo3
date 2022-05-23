using Platformer.Infrastructure.Persistent.Data;

namespace Platformer.Infrastructure.Persistent
{
    public class PersistentService : IPersistentService
    {
        public PersistentData Data { get;  set; }
    }
}