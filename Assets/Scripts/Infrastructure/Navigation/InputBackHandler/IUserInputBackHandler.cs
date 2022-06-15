using System;

namespace Platformer.Infrastructure.Navigation.InputBackHandler
{
    public interface IUserInputBackHandler
    {
        void OnBack(Action onBackCallback);
    }
}