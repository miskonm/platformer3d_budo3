using Platformer.Infrastructure.Navigation.Screens.Shop;

namespace Platformer.Infrastructure.Navigation.Screens.Loading
{
    public class ShopScreenPresenter : UiScreenPresenter<ShopScreen, ShopScreenArgs>
    {
        protected override void OnShowBegin()
        {
            base.OnShowBegin();

            view.Setup(args.SomeText);
        }
    }
}