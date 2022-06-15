using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Base
{
    public abstract class UiViewPresenter<TView, TArgs> : MonoBehaviour, IViewPresenter
        where TView : BaseView where TArgs : class, IViewArgs
    {
        protected TView view;
        protected TArgs args;

        public CanvasGroup CanvasGroup => view.CanvasGroup;

        protected void Awake()
        {
            view = GetComponent<TView>();
        }

        public virtual void Initialize(IViewArgs viewArgs)
        {
            args = viewArgs as TArgs;
            OnInitialized();
        }

        public async UniTask ShowView()
        {
            gameObject.SetActive(true);
            OnShowBegin();

            await view.Show();

            CanvasGroup.interactable = true;
            OnShowEnd();
        }

        public async UniTask HideView()
        {
            CanvasGroup.interactable = false;
            OnHideBegin();

            await view.Hide();

            OnHideEnd();
            gameObject.SetActive(false);
        }

        // TODO: Think about it
        public bool IsView<TViewCheck>() where TViewCheck : BaseView =>
            view is TViewCheck;

        public void Destroy() =>
            UnityEngine.Object.Destroy(gameObject);

        protected virtual void OnInitialized() { }
        protected virtual void OnShowBegin() { }
        protected virtual void OnShowEnd() { }
        protected virtual void OnHideBegin() { }
        protected virtual void OnHideEnd() { }
    }
}