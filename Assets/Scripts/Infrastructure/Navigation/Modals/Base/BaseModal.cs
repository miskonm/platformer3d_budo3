using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Infrastructure.Navigation.Modals.Base
{
    public class BaseModal : UiModal
    {
        [Header(nameof(BaseModal))]
        [SerializeField] private Button _applyButton;

        public event Action OnApplyButtonClicked;
        
        protected override void Awake()
        {
            base.Awake();
            
            _applyButton.onClick.AddListener(() => OnApplyButtonClicked?.Invoke());
        }
    }
}