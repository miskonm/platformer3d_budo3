using Platformer.Game.Logger;
using Platformer.Game.Services.Pause;
using Zenject;

namespace Platformer.Game
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameLoggerInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
        }
    }
}