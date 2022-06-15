using Platformer.Infrastructure.Navigation.Base;
using Platformer.Infrastructure.Navigation.Modals;

namespace Platformer.Infrastructure.Navigation.Container
{
    public interface IUiContainer
    {
        string GetScreenPath<TView>() where TView : BaseView;
        string GetModalPath(ModalName modalName);
    }
}