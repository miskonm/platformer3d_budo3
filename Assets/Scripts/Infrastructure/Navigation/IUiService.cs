using Cysharp.Threading.Tasks;
using Platformer.Infrastructure.Navigation.Modals;
using Platformer.Infrastructure.Navigation.Screens;

namespace Platformer.Infrastructure.Navigation
{
    public interface IUiService
    {
        UniTask OpenScreen<TScreen>(IScreenArgs args = null) where TScreen : UiScreen;
        UniTask CloseScreen<TScreen>() where TScreen : UiScreen;
        
        UniTask OpenModal(ModalName modalName, IModalArgs args = null);
        UniTask CloseModal(ModalName modalName);
        
        void CloseAll();
    }
}