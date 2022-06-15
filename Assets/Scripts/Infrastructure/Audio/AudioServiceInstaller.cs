using Zenject;

namespace Platformer.Infrastructure.Audio
{
    public class AudioServiceInstaller : MonoInstaller
    {
        public AudioContainer AudioContainer;

        public override void InstallBindings()
        {
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
            Container.Bind<AudioContainer>().FromInstance(AudioContainer).AsSingle();
        }
    }
}