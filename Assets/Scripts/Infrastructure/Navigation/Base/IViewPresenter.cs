using Cysharp.Threading.Tasks;

namespace Platformer.Infrastructure.Navigation.Base
{
    public interface IViewPresenter
    {
        void Initialize(IViewArgs viewArgs);
        UniTask ShowView();
        UniTask HideView();
        bool IsView<TViewCheck>() where TViewCheck : BaseView;
        void Destroy();
    }
}