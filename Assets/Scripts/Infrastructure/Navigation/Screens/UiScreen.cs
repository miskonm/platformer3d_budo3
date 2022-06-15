using System;
using Platformer.Infrastructure.Navigation.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Infrastructure.Navigation.Screens
{
    [RequireComponent(typeof(CanvasGroup))]
    public abstract class UiScreen : BaseView
    {
        [Header(nameof(UiScreen))]
        [SerializeField] private Button _backButton;

        public event Action OnBackButtonClicked;

        protected override void Awake()
        {
            base.Awake();

            if (_backButton != null)
            {
                _backButton.onClick.AddListener(() => OnBackButtonClicked?.Invoke());
            }
        }
    }
}