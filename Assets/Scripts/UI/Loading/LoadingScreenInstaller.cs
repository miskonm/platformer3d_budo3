using Zenject;

namespace Platformer.UI.Loading
{
    public class LoadingScreenInstaller : MonoInstaller
    {
        public LoadingScreen LoadingScreenPrefab;

        public override void InstallBindings()
        {
            Container
                .Bind<ILoadingScreen>()
                .To<LoadingScreen>()
                .FromComponentInNewPrefab(LoadingScreenPrefab)
                .AsSingle();
        }
    }
}