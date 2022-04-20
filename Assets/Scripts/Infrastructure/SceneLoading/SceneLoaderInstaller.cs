using Zenject;

namespace Platformer.Infrastructure.SceneLoading
{
    public class SceneLoaderInstaller : Installer<SceneLoaderInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsTransient();
        }
    }
}