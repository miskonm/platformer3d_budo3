namespace Platformer.Infrastructure.Navigation.Utils
{
    public static class UnityObjectExtensions
    {
        public static T NotNull<T>(this T obj) where T : UnityEngine.Object =>
            obj == null ? null : obj;
    }
}