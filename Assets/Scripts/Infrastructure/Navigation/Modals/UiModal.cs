using System;
using Platformer.Infrastructure.Navigation.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Infrastructure.Navigation.Modals
{
    public abstract class UiModal : BaseView
    {
        [Header(nameof(UiModal))]
        [SerializeField] private Button _closeButton;
        [SerializeField] private bool _isCloseWithBackButton = true;

        public event Action OnCloseButtonClicked;
        
        public bool IsCloseWithBackButton => _isCloseWithBackButton;

        protected override void Awake()
        {
            base.Awake();
            
            if (_closeButton != null)
            {
                _closeButton.onClick.AddListener(() => OnCloseButtonClicked?.Invoke());
            }
        }
    }
}