using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Utils
{
    public static class CanvasGroupExtensions
    {
        public static void SetVisible(this CanvasGroup canvasGroup, bool isVisible) =>
            canvasGroup.alpha = isVisible ? 1f : 0f;
    }
}