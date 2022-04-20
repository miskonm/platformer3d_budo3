using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.StateMachine
{
    public class AppStateFactoryContainerSetter : MonoBehaviour
    {
        [Inject]
        public void Construct(DiContainer diContainer, IAppStateFactory stateFactory) =>
            stateFactory.SetContainer(diContainer);
    }
}