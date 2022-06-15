using System;
using Platformer.Infrastructure.Navigation.Base;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Screens
{
    [RequireComponent(typeof(UiScreen))]
    public abstract class UiScreenPresenter<TScreen, TArgs> : UiViewPresenter<TScreen, TArgs> , IScreenPresenter
        where TScreen : UiScreen where TArgs : class, IScreenArgs
    {
        private Action _onBackCallback;

        public void OnBack(Action onBackCallback) =>
            _onBackCallback = onBackCallback;
        

        protected override void OnShowEnd()
        {
            base.OnShowEnd();
            view.OnBackButtonClicked += Back;
        }

        protected override void OnHideBegin()
        {
            view.OnBackButtonClicked -= Back;
            base.OnHideBegin();
        }

        protected virtual void Back() =>
            _onBackCallback?.Invoke();
    }

    [RequireComponent(typeof(UiScreen))]
    public abstract class UiScreenPresenter<TScreen> : UiScreenPresenter<TScreen, IScreenArgs>
        where TScreen : UiScreen 
    {
    }
}