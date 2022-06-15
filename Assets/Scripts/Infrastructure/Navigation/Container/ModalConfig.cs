using System;
using Platformer.Infrastructure.Navigation.Modals;

namespace Platformer.Infrastructure.Navigation.Container
{
    [Serializable]
    public class ModalConfig : ViewConfig
    {
        public ModalName ModalName;
    }
}