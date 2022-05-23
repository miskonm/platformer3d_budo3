using Platformer.Infrastructure.Persistent.Data;

namespace Platformer.Infrastructure.Persistent
{
    public interface IPersistentService
    {
        public PersistentData Data { get; set; }
    }
}