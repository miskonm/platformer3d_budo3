using Zenject;

namespace Platformer.Infrastructure.StateMachine
{
    public class AppStateMachineInstaller : Installer<AppStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IAppStateFactory>().To<AppStateFactory>().AsSingle();
            Container.BindInterfacesTo<AppStateMachine>().AsSingle();
        }
    }
}