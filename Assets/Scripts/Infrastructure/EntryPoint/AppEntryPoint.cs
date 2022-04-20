using Platformer.Infrastructure.StateMachine;
using Platformer.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.EntryPoint
{
    public class AppEntryPoint : MonoBehaviour
    {
        private IAppStateMachine _appStateMachine;

        [Inject]
        public void Construct(IAppStateMachine appStateMachine)
        {
            _appStateMachine = appStateMachine;
        }

        private void Start()
        {
            _appStateMachine.Enter<BootstrapState>();
        }
    }
}