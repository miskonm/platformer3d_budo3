using Zenject;

namespace Platformer.Game.UI.Pause
{
    public class PauseScreenInstaller : MonoInstaller
    {
        public PauseScreen PauseScreen;

        public override void InstallBindings()
        {
            Container.Bind<IPauseScreen>().To<PauseScreen>().FromInstance(PauseScreen).AsSingle();
        }
    }
}