using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.Infrastructure.Navigation.Screens.Menu
{
    public class MenuScreen : UiScreen
    {
        [Header(nameof(MenuScreen))]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _shopButton;

        public event Action OnPlayButtonClicked;
        public event Action OnShopButtonClicked;

        protected override void Awake()
        {
            base.Awake();

            _playButton.onClick.AddListener(() => OnPlayButtonClicked?.Invoke());
            _shopButton.onClick.AddListener(() => OnShopButtonClicked?.Invoke());
        }
    }
}