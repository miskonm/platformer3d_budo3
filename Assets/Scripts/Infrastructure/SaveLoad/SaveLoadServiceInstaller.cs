using Platformer.Infrastructure.SaveLoad.IO;
using Zenject;

namespace Platformer.Infrastructure.SaveLoad
{
    public class SaveLoadServiceInstaller : Installer<SaveLoadServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();

            Container.Bind<ISaveLoadIO>().To<JsonPrefsSaveLoadIO>().AsSingle();
        }
    }
}