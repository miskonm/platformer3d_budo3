namespace Platformer.Infrastructure.Navigation.Modals.Base
{
    public class BaseModalPresenter : UiModalPresenter<BaseModal>
    {
        protected override void OnShowEnd()
        {
            base.OnShowEnd();
            
            view.OnApplyButtonClicked += ApplyButtonClicked;
        }

        protected override void OnHideBegin()
        {
            view.OnApplyButtonClicked -= ApplyButtonClicked;

            base.OnHideBegin();
        }

        private void ApplyButtonClicked()
        {
            Close();
            args?.onAccepted?.Invoke();
        }
    }
}