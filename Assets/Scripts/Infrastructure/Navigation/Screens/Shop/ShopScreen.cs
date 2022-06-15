using TMPro;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Screens.Loading
{
    public class ShopScreen : UiScreen
    {
        [Header(nameof(ShopScreen))]
        [SerializeField] private TextMeshProUGUI _headerLabel;

        public void Setup(string headerText) =>
            _headerLabel.text = headerText;
    }
}