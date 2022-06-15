using System;
using Platformer.Infrastructure.Navigation.Base;

namespace Platformer.Infrastructure.Navigation.Modals
{
    public interface IModalPresenter : IViewPresenter
    {
        bool IsCloseWithBackButton { get; }
        
        void OnClose(Action onCloseCallback);
        bool IsModal(ModalName modalName);
        void SetName(ModalName modalName);
    }
}