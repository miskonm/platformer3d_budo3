using System.Collections.Generic;
using Platformer.Infrastructure.Navigation.Base;
using Platformer.Infrastructure.Navigation.Modals;
using Platformer.Infrastructure.Navigation.Utils;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Container
{
    [CreateAssetMenu(fileName = Tag, menuName = "Configs/UI/UiContainer")]
    public class UiContainer : ScriptableObject, IUiContainer
    {
        private const string Tag = nameof(UiContainer);

        [SerializeField] private ScreenConfig[] _screenConfigs;
        [SerializeField] private ModalConfig[] _modalConfigs;

        private readonly Dictionary<string, ScreenConfig> _screenConfigsCache = new Dictionary<string, ScreenConfig>();
        private readonly Dictionary<ModalName, ModalConfig> _modalConfigsCache =
            new Dictionary<ModalName, ModalConfig>();

        private void OnEnable()
        {
            FillCache();
        }

        public string GetScreenPath<TView>() where TView : BaseView
        {
            string type = Name<TView>();

            return !_screenConfigsCache.ContainsKey(type) ? null : _screenConfigsCache[type].Path;
        }

        public string GetModalPath(ModalName modalName) =>
            _modalConfigsCache.TryGetValue(modalName, out ModalConfig config) ? config.Path : null;

        public void EditorUpdate()
        {
            ScreenConfigsUpdate();
            ModalConfigsUpdate();
        }

        private static string Name<TView>() where TView : BaseView =>
            typeof(TView).Name;

        private void ScreenConfigsUpdate()
        {
            if (_screenConfigs == null || _screenConfigs.Length == 0)
            {
                return;
            }

            _screenConfigs.ForEach(config => { config.OnValidate(); });
        }

        private void ModalConfigsUpdate()
        {
            if (_modalConfigs == null || _modalConfigs.Length == 0)
            {
                return;
            }

            _modalConfigs.ForEach(config => { config.OnValidate(); });
        }

        private void FillCache()
        {
            _screenConfigsCache.Fill(Tag, _screenConfigs, config => config.Type);
            _modalConfigsCache.Fill(Tag, _modalConfigs, config => config.ModalName);
        }
    }
}