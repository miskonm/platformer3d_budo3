using Zenject;

namespace Platformer.Infrastructure.Assets
{
    public class ResourcesAssetsServiceInstaller : Installer<ResourcesAssetsServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IResourcesAssetsService>().To<ResourcesAssetsService>().AsSingle();
        }
    }
}