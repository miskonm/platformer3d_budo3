using Zenject;

namespace Platformer.Infrastructure.Debug
{
    public class DebugGuiInstaller : MonoInstaller
    {
        public DebugGui Instance;

        public override void InstallBindings()
        {
            Container.Bind<IDebugGui>().To<DebugGui>().FromInstance(Instance).AsSingle();
        }
    }
}