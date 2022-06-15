using System;
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.InputBackHandler
{
    public class AndroidUserInputBackHandler : MonoBehaviour, IUserInputBackHandler
    {
        private Action _onBackCallback;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _onBackCallback?.Invoke();
            }
        }

        public void OnBack(Action onBackCallback) =>
            _onBackCallback = onBackCallback;
    }
}