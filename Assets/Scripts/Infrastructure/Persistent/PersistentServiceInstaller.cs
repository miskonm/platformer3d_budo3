using Zenject;

namespace Platformer.Infrastructure.Persistent
{
    public class PersistentServiceInstaller : Installer<PersistentServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IPersistentService>().To<PersistentService>().AsSingle();
        }
    }
}