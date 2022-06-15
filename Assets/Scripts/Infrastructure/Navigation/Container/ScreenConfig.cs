using System;
using Platformer.Infrastructure.Navigation.Screens;
using Platformer.Infrastructure.Navigation.Utils;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Container
{
    [Serializable]
    public class ScreenConfig : ViewConfig
    {
        [HideInInspector]
        public string Type;

        protected override void SetGameObject(GameObject go) =>
            Type = go == null ? string.Empty : go.GetComponentInChildren<UiScreen>().NotNull()?.GetType().Name;
    }
}