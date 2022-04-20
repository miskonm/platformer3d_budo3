using Platformer.Game.Logger;
using Zenject;

namespace Platformer.Game
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameLoggerInstaller.Install(Container);
        }
    }
}