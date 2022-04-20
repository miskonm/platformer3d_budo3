using Zenject;

namespace Platformer.Game.Logger
{
    public class GameLoggerInstaller : Installer<GameLoggerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameLogger>().To<GameLogger>().AsSingle();
        }
    }
}