using System;
using System.Collections.Generic;
using DG.Tweening;
using Platformer.Infrastructure.SceneLoading;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Platformer.Game.UI.Pause
{
    public class PauseScreen : MonoBehaviour, IPauseScreen
    {
        [Header("Animation")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration = 1f;

        [Header("Buttons")]
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _menuButton;

        private ISceneLoader _sceneLoader;
        private Tween _tween;

        public event Action OnContinueButtonClicked;

        public bool IsAnimating { get; private set; }

        [Inject]
        public void Construct(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            SetActiveCursor(false);
            _continueButton.onClick.AddListener(() => OnContinueButtonClicked?.Invoke());
            _menuButton.onClick.AddListener(MenuButtonClicked);
            _canvasGroup.alpha = 0;
        }

        public async void Show()
        {
            SetActiveCursor(true);

            IsAnimating = true;
            _tween?.Kill();
            _tween = _canvasGroup.DOFade(1f, _fadeDuration).SetUpdate(UpdateType.Normal, true);
            await _tween.AsyncWaitForCompletion();
            IsAnimating = false;
        }

        public async void Hide()
        {
            SetActiveCursor(false);

            IsAnimating = true;
            _tween?.Kill();
            _tween = _canvasGroup.DOFade(0f, _fadeDuration);
            await _tween.AsyncWaitForCompletion();
            IsAnimating = false;
        }

        private void SetActiveCursor(bool isActive)
        {
            Cursor.visible = isActive;
            Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
        }

        private async void MenuButtonClicked()
        {
            _menuButton.enabled = false;
            await _sceneLoader.LoadSceneAsync(SceneName.Menu);
        }
    }
}