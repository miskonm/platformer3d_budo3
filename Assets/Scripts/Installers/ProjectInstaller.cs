using Platformer.Infrastructure.Coroutines;
using Platformer.Infrastructure.SceneLoading;
using Platformer.Infrastructure.StateMachine;
using Zenject;

namespace Platformer.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            AppStateMachineInstaller.Install(Container);
            SceneLoaderInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
        }
    }
}