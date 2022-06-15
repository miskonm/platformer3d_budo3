using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Platformer.Infrastructure.Assets;
using Platformer.Infrastructure.Navigation.Base;
using Platformer.Infrastructure.Navigation.Container;
using Platformer.Infrastructure.Navigation.Modals;
using Platformer.Infrastructure.Navigation.Screens;
using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.Navigation.Factory
{
    public class UiFactory : IUiFactory
    {
        private const string TAG = nameof(UiFactory);

        private readonly IResourcesAssetsService _assetsService;
        private readonly IUiContainer _uiContainer;
        private readonly IInstantiator _instantiator;

        private readonly Dictionary<Type, GameObject> _screenContainersCache = new Dictionary<Type, GameObject>();
        private readonly Dictionary<ModalName, GameObject> _modalContainersCache =
            new Dictionary<ModalName, GameObject>();

        public UiFactory(IInstantiator instantiator, IResourcesAssetsService assetsService, IUiContainer uiContainer)
        {
            _instantiator = instantiator;
            _assetsService = assetsService;
            _uiContainer = uiContainer;
        }

        public async UniTask<IScreenPresenter> Create<TScreen>(Transform under, IScreenArgs screenArgs)
            where TScreen : UiScreen
        {
            return await GetScreenPresenter<TScreen>(under, screenArgs);
        }

        public async UniTask<IModalPresenter> Create(Transform under, ModalName modalName, IModalArgs modalArgs) =>
            await GetModalPresenter(under, modalName, modalArgs);

        private async UniTask<IScreenPresenter> GetScreenPresenter<TView>(Transform under, IViewArgs viewArgs)
            where TView : BaseView
        {
            Type screenType = typeof(TView);
            if (!_screenContainersCache.ContainsKey(screenType))
            {
                await CacheScreenContainer<TView>();
            }

            if (!_screenContainersCache.ContainsKey(screenType))
            {
                return null;
            }

            GameObject prefab = _screenContainersCache[screenType];
            return await InstantiatePresenter<IScreenPresenter>(under, viewArgs, prefab, screenType.Name);
        }

        private async UniTask<IModalPresenter> GetModalPresenter(Transform under, ModalName modalName,
            IModalArgs modalArgs)
        {
            if (!_modalContainersCache.ContainsKey(modalName))
            {
                await CacheModalContainer(modalName);
            }

            if (!_modalContainersCache.ContainsKey(modalName))
            {
                return null;
            }

            GameObject prefab = _modalContainersCache[modalName];
            IModalPresenter presenter =
                await InstantiatePresenter<IModalPresenter>(under, modalArgs, prefab, modalName.ToString());

            if (presenter == null)
            {
                return null;
            }

            presenter.SetName(modalName);
            return presenter;
        }

        private async UniTask<TPresenter> InstantiatePresenter<TPresenter>(Transform under, IViewArgs viewArgs,
            GameObject prefab, string screenName) where TPresenter : class, IViewPresenter
        {
            GameObject screenObject = _instantiator.InstantiatePrefab(prefab);
            TPresenter presenter = screenObject.GetComponent<TPresenter>();
            if (presenter == null)
            {
                UnityEngine.Debug.LogError($"{TAG},{nameof(InstantiatePresenter)}: Prefab with id {screenName} don't " +
                    $"contains {typeof(TPresenter).Name}");
                return null;
            }

            presenter.Initialize(viewArgs);
            return presenter;
        }

        private async UniTask CacheModalContainer(ModalName modalName)
        {
            string modalPath = _uiContainer.GetModalPath(modalName);
            GameObject prefab = await _assetsService.GetAsset<GameObject>(modalPath);

            if (prefab == null)
            {
                UnityEngine.Debug.LogError(
                    $"{TAG},{nameof(CacheModalContainer)}: There is no prefab for modal {modalName}");
                return;
            }

            _modalContainersCache[modalName] = prefab;
        }

        private async UniTask CacheScreenContainer<TView>() where TView : BaseView
        {
            string screenPath = _uiContainer.GetScreenPath<TView>();
            GameObject prefab = await _assetsService.GetAsset<GameObject>(screenPath);

            Type type = typeof(TView);

            if (prefab == null)
            {
                UnityEngine.Debug.LogError(
                    $"{TAG},{nameof(CacheScreenContainer)}: There is no prefab for type {type}");
                return;
            }

            _screenContainersCache[type] = prefab;
        }
    }
}