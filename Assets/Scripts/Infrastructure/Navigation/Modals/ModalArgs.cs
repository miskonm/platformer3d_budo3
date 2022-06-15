using System;

namespace Platformer.Infrastructure.Navigation.Modals
{
    public class ModalArgs : IModalArgs
    {
        public Action onAccepted;

        public ModalArgs(Action onAcceptedCallback)
        {
            onAccepted = onAcceptedCallback;
        }
    }
}