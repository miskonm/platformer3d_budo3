using System;
using Platformer.Infrastructure.Navigation.Base;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Modals
{
    [RequireComponent(typeof(UiModal))]
    public abstract class UiModalPresenter<TModal, TArgs> : UiViewPresenter<TModal, TArgs>, IModalPresenter
        where TModal : UiModal where TArgs : class, IModalArgs
    {
        private Action _onCloseCallback;
        private ModalName _modalName;

        public bool IsCloseWithBackButton => view.IsCloseWithBackButton;

        public void OnClose(Action onCloseCallback) =>
            _onCloseCallback = onCloseCallback;

        public bool IsModal(ModalName modalName) =>
            _modalName == modalName;

        public void SetName(ModalName modalName) =>
            _modalName = modalName;

        protected override void OnShowEnd()
        {
            base.OnShowEnd();
            view.OnCloseButtonClicked += Close;
        }

        protected override void OnHideBegin()
        {
            view.OnCloseButtonClicked -= Close;
            base.OnHideBegin();
        }

        protected virtual void Close() =>
            _onCloseCallback?.Invoke();
    }

    [RequireComponent(typeof(UiModal))]
    public abstract class UiModalPresenter<TModal> : UiModalPresenter<TModal, ModalArgs> where TModal : UiModal
    {
    }
}