using Platformer.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.Debug
{
    public class DebugGui : MonoBehaviour, IDebugGui
    {
        private IDebugAppStateMachine _debugAppStateMachine;
        
        [SerializeField] private bool _isOn;

        [Inject]
        public void Construct(IDebugAppStateMachine debugAppStateMachine)
        {
            _debugAppStateMachine = debugAppStateMachine;
        }

        private void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE
            if (Input.GetMouseButtonDown(1))
            {
                _isOn = !_isOn;
            }
#else
            if (Input.touchCount == 4)
            {
                _isOn = !_isOn; 
            }
#endif
        }

        private void OnGUI()
        {
            if (!_isOn)
                return;
            
            // if prod || dev
            // Show fps
            // Show info
            
            // if dev
            // Show dev buttons
            // Show help buttons

            if (GUI.Button(new Rect(0, Screen.height - 100, 100, 30), "test"))
            {
                UnityEngine.Debug.Log($"Test");
            }

            string stateLabel = $"Current state: {_debugAppStateMachine.CurrentState}";
            GUI.Label(new Rect(0, 0, 300, 100), stateLabel);
        }
    }
}