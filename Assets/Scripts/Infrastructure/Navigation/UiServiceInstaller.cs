using Platformer.Infrastructure.Navigation.Container;
using Platformer.Infrastructure.Navigation.Factory;
using Platformer.Infrastructure.Navigation.InputBackHandler;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.Navigation
{
    public class UiServiceInstaller : MonoInstaller
    {
        public Transform parent;
        public UiContainer uiContainer;
        
        public override void InstallBindings()
        {
            Container.Bind<IUiInternalFactory>().To<UiInternalFactory>().AsSingle();
            
            Container
                .Bind<IUiService>()
                .FromSubContainerResolve()
                .ByMethod(BindService)
                .AsSingle();
        }

        private void BindService(DiContainer subContainer)
        {
            subContainer.Bind<IUiService>().To<UiService>().AsSingle();
            subContainer.Bind<IUiFactory>().To<UiFactory>().AsSingle();

            subContainer
                .Bind<Transform>()
                .FromInstance(parent)
                .AsSingle();
            
            subContainer
                .Bind<IUiContainer>()
                .To<UiContainer>()
                .FromInstance(uiContainer)
                .AsSingle();

            if (Application.platform == RuntimePlatform.Android)
            {
                subContainer
                    .Bind<IUserInputBackHandler>()
                    .To<AndroidUserInputBackHandler>()
                    .FromNewComponentOnNewGameObject()
                    .AsSingle();
            }
            else
            {
                subContainer
                    .Bind<IUserInputBackHandler>()
                    .To<DummyUserInputBackHandler>()
                    .AsSingle();
            }
        }
    }
}