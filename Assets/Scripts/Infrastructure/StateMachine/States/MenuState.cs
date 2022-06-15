using Platformer.Infrastructure.Navigation;
using Platformer.Infrastructure.Navigation.Screens.Menu;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class MenuState : BaseState
    {
        private readonly IUiService _uiService;

        public MenuState(IUiService uiService)
        {
            _uiService = uiService;
        }

        public override void Enter()
        {
            _uiService.OpenScreen<MenuScreen>();
        }

        public override void Exit()
        {
        }
    }
}