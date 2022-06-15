using Zenject;

namespace Platformer.Game.Services.Assets
{
    public class AssetsServiceInstaller : Installer<AssetsServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetsService>().To<AssetsService>().AsSingle();
        }
    }
}