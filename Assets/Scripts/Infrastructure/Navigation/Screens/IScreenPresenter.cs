using System;
using Platformer.Infrastructure.Navigation.Base;

namespace Platformer.Infrastructure.Navigation.Screens
{
    public interface IScreenPresenter : IViewPresenter
    {
        void OnBack(Action onBackCallback);
    }
}