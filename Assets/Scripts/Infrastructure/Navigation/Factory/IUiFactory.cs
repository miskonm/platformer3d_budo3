using Cysharp.Threading.Tasks;
using Platformer.Infrastructure.Navigation.Modals;
using Platformer.Infrastructure.Navigation.Screens;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Factory
{
    public interface IUiFactory
    {
        UniTask<IScreenPresenter> Create<TScreen>(Transform under, IScreenArgs screenArgs) where TScreen : UiScreen;
        UniTask<IModalPresenter> Create(Transform under, ModalName modalName, IModalArgs modalArgs);
    }
}