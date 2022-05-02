using System.Collections;
using Platformer.Game.UI.Pause;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Services.Pause
{
    public class PauseService : MonoBehaviour, IPauseService
    {
        private IPauseScreen _pauseScreen;

        private bool _isUiAnimating;

        public bool IsPaused { get; private set; }

        [Inject]
        public void Construct(IPauseScreen pauseScreen)
        {
            _pauseScreen = pauseScreen;
        }

        private void Start()
        {
            _pauseScreen.OnContinueButtonClicked += TogglePause;
        }

        private void OnDestroy()
        {
            _pauseScreen.OnContinueButtonClicked -= TogglePause;
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape) && !_pauseScreen.IsAnimating)
                TogglePause();
        }

        private void TogglePause()
        {
            IsPaused = !IsPaused;

            Time.timeScale = IsPaused ? 0 : 1;

            if (IsPaused)
                _pauseScreen.Show();
            else 
                _pauseScreen.Hide();
        }
    }
}