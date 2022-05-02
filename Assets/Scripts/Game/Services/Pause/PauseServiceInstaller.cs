using Zenject;

namespace Platformer.Game.Services.Pause
{
    public class PauseServiceInstaller : Installer<PauseServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPauseService>()
                .To<PauseService>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}