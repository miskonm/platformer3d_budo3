using Platformer.Infrastructure.Navigation.Modals;
using Platformer.Infrastructure.Navigation.Screens.Loading;
using Platformer.Infrastructure.Navigation.Screens.Shop;
using Platformer.Infrastructure.StateMachine;
using Platformer.Infrastructure.StateMachine.States;
using Zenject;

namespace Platformer.Infrastructure.Navigation.Screens.Menu
{
    public class MenuScreenPresenter : UiScreenPresenter<MenuScreen>
    {
        private IUiService _uiService;
        private IAppStateMachine _stateMachine;

        [Inject]
        public void Construct(IUiService uiService, IAppStateMachine stateMachine)
        {
            _uiService = uiService;
            _stateMachine = stateMachine;
        }

        protected override void OnShowEnd()
        {
            base.OnShowEnd();

            view.OnPlayButtonClicked += PlayButtonClicked;
            view.OnShopButtonClicked += ShopButtonClicked;
        }

        protected override void OnHideBegin()
        {
            view.OnPlayButtonClicked -= PlayButtonClicked;
            view.OnShopButtonClicked -= ShopButtonClicked;

            base.OnHideBegin();
        }

        private void PlayButtonClicked() =>
            _uiService.OpenModal(ModalName.PlayConfirmation, new ModalArgs(Play));

        private void Play() =>
            _stateMachine.Enter<StartLoadingGameState>();

        private void ShopButtonClicked() =>
            _uiService.OpenScreen<ShopScreen>(new ShopScreenArgs("Just example to show!"));
    }
}