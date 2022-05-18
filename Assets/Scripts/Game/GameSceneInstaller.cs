using Platformer.Game.Logger;
using Platformer.Game.Services.Factory;
using Platformer.Game.Services.Pause;
using Platformer.Game.Services.StaticData;
using Zenject;

namespace Platformer.Game
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameLoggerInstaller.Install(Container);
            PauseServiceInstaller.Install(Container);
            StaticDataServiceInstaller.Install(Container);
            GameFactoryInstaller.Install(Container);
        }
    }
}