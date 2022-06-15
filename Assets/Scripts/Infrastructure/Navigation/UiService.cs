using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Platformer.Infrastructure.Navigation.Factory;
using Platformer.Infrastructure.Navigation.InputBackHandler;
using Platformer.Infrastructure.Navigation.Modals;
using Platformer.Infrastructure.Navigation.Screens;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation
{
    public class UiService : IUiService
    {
        private const string TAG = nameof(UiService);

        private readonly Transform _parentTransform;
        private readonly IUiFactory _uiFactory;

        // TODO: Add cache for screen
        private readonly Stack<IScreenPresenter> _screensStack = new Stack<IScreenPresenter>();

        // TODO: Add modal queue if needed
        private IModalPresenter _currentModal;

        public UiService(Transform parentTransform, IUiFactory uiFactory,
            IUserInputBackHandler userInputBackHandler)
        {
            _parentTransform = parentTransform;
            _uiFactory = uiFactory;

            userInputBackHandler.OnBack(Back);
        }

        public async UniTask OpenScreen<TScreen>(IScreenArgs args = null) where TScreen : UiScreen
        {
            IScreenPresenter presenter = await GetPresenter<TScreen>(args);

            await OpenScreenInternal<TScreen>(presenter);
        }

        public async UniTask CloseScreen<TScreen>() where TScreen : UiScreen
        {
            if (_screensStack.Peek().IsView<TScreen>())
            {
                IScreenPresenter presenter = _screensStack.Pop();
                await presenter.HideView();
                Destroy(presenter);

                if (_screensStack.Count > 0)
                {
                    await _screensStack.Peek().ShowView();
                }
            }
            else
            {
                // TODO: LOG
            }
        }

        public void CloseAll()
        {
            if (_currentModal != null)
            {
                _currentModal.Destroy();
                _currentModal = null;
            }
            
            while (_screensStack.Count > 0)
            {
                IScreenPresenter presenter = _screensStack.Pop();
                presenter.Destroy();
            }
        }

        public async UniTask OpenModal(ModalName modalName, IModalArgs args = null)
        {
            IModalPresenter modalPresenter = await GetPresenter(modalName, args);
            await OpenModalInternal(modalPresenter, modalName);
        }

        public async UniTask CloseModal(ModalName modalName)
        {
            if (_currentModal == null)
            {
                UnityEngine.Debug.LogWarning($"{TAG},{nameof(CloseModal)}: Try to close modal '{modalName}' when " +
                    $"no active modal shown.");
                return;
            }

            if (!_currentModal.IsModal(modalName))
            {
                UnityEngine.Debug.LogWarning($"{TAG},{nameof(CloseModal)}: Try to close modal '{modalName}' when " +
                    $"other modal shown.");
                return;
            }

            await HideCurrentModal();
        }

        private async UniTask OpenScreenInternal<TScreen>(IScreenPresenter presenter) where TScreen : UiScreen
        {
            if (presenter == null)
            {
                UnityEngine.Debug.LogError($"{TAG},{nameof(OpenScreen)}: There is no screen with type {typeof(TScreen)}");
                return;
            }

            presenter.OnBack(Back);

            if (_screensStack.Count > 0)
            {
                IScreenPresenter currentPresenter = _screensStack.Peek();

                await currentPresenter.HideView();
            }

            _screensStack.Push(presenter);

            await presenter.ShowView();
        }

        private async UniTask OpenModalInternal(IModalPresenter presenter, ModalName modalName) 
        {
            if (presenter == null)
            {
                UnityEngine.Debug.LogError($"{TAG},{nameof(OpenModalInternal)}: There is no modal {modalName}");
                return;
            }

            presenter.OnClose(CloseModalInternal);

            if (_currentModal != null)
            {
                await HideCurrentModal();
            }

            _currentModal = presenter;
            await presenter.ShowView();
        }

        private async void CloseModalInternal() =>
            await HideCurrentModal();

        private async void Back()
        {
            if (_currentModal != null)
            {
                if (_currentModal.IsCloseWithBackButton)
                {
                    await HideCurrentModal();
                }
                
                return;
            }

            if (_screensStack.Count <= 1)
            {
                return;
            }

            IScreenPresenter screenPresenter = _screensStack.Pop();
            await screenPresenter.HideView();
            Destroy(screenPresenter);

            IScreenPresenter presenter = _screensStack.Peek();
            await presenter.ShowView();
        }

        private async UniTask HideCurrentModal()
        {
            await _currentModal.HideView();
            _currentModal.Destroy();
            _currentModal = null;
        }

        private void Destroy(IScreenPresenter presenter) =>
            presenter.Destroy();

        private async UniTask<IScreenPresenter> GetPresenter<TScreen>(IScreenArgs screenArgs) where TScreen : UiScreen =>
            await _uiFactory.Create<TScreen>(_parentTransform, screenArgs);

        private async UniTask<IModalPresenter> GetPresenter(ModalName modalName, IModalArgs modalArgs) =>
            await _uiFactory.Create(_parentTransform, modalName, modalArgs);
    }
}