using Zenject;

namespace Platformer.Game.Services.StaticData
{
    public class StaticDataServiceInstaller : Installer<StaticDataServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        }
    }
}