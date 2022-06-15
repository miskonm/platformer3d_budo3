using Cysharp.Threading.Tasks;
using Platformer.Infrastructure.Navigation.Factory;
using Platformer.Infrastructure.Navigation.Utils;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.Navigation.Base
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class BaseView : MonoBehaviour
    {
        protected IUiInternalFactory uiInternalFactory;

        public CanvasGroup CanvasGroup { get; private set; }

        [Inject]
        public void Construct(IUiInternalFactory uiInternalFactory)
        {
            this.uiInternalFactory = uiInternalFactory;
        }

        protected virtual void Awake()
        {
            CanvasGroup = GetComponent<CanvasGroup>();
            CanvasGroup.SetVisible(false);
        }

        public virtual async UniTask Show()
        {
            // await CanvasGroup.DOFade(1f, 0f).ToUniTask();
            CanvasGroup.SetVisible(true);
        }

        public virtual async UniTask Hide()
        {
            // await CanvasGroup.DOFade(0f, 0f).ToUniTask();
            CanvasGroup.SetVisible(false);
        }
    }
}