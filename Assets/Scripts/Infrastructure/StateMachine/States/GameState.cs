using Platformer.Game.Services.Assets;

namespace Platformer.Infrastructure.StateMachine.States
{
    public class GameState : BaseState
    {
        private readonly IAssetsService _assetsService;

        public GameState(IAssetsService assetsService)
        {
            _assetsService = assetsService;
        }

        public override void Enter()
        {
            
        }

        public override void Exit()
        {
            _assetsService.Clean();
        }
    }
}