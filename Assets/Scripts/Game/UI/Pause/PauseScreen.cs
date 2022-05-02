using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Game.UI.Pause
{
    public class PauseScreen : MonoBehaviour, IPauseScreen
    {
        [Header("Animation")]
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private float _fadeDuration = 1f;

        [Header("Buttons")]
        [SerializeField] private Button _continueButton;

        private Tween _tween;

        public bool IsAnimating { get; private set; }
        
        public event Action OnContinueButtonClicked;

        private void Awake()
        {
            _continueButton.onClick.AddListener(() => OnContinueButtonClicked?.Invoke());
            _canvasGroup.alpha = 0;
        }

        public async void Show()
        {
            IsAnimating = true;
            _tween?.Kill();
            _tween = _canvasGroup.DOFade(1f, _fadeDuration).SetUpdate(UpdateType.Normal, true);
            await _tween.AsyncWaitForCompletion();
            IsAnimating = false;
        }

        public async void Hide()
        {
            IsAnimating = true;
            _tween?.Kill();
            _tween = _canvasGroup.DOFade(0f, _fadeDuration);
            await _tween.AsyncWaitForCompletion();
            IsAnimating = false;
        }
    }
}