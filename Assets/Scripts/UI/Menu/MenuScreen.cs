using Platformer.Infrastructure.StateMachine;
using Platformer.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer.UI.Menu
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _playButton;

        private IAppStateMachine _stateMachine;

        [Inject]
        public void Construct(IAppStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        private void Awake()
        {
            _playButton.onClick.AddListener(Click);
        }

        private void Click()
        {
            _stateMachine.Enter<StartLoadingGameState>();
        }
    }
}