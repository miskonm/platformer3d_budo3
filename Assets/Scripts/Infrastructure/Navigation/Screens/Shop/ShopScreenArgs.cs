namespace Platformer.Infrastructure.Navigation.Screens.Shop
{
    public class ShopScreenArgs : IScreenArgs
    {
        public string SomeText;

        public ShopScreenArgs(string someText)
        {
            SomeText = someText;
        }
    }
}