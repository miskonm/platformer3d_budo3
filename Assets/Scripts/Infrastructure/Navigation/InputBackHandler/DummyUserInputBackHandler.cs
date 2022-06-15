using System;

namespace Platformer.Infrastructure.Navigation.InputBackHandler
{
    public class DummyUserInputBackHandler : IUserInputBackHandler
    {
        public void OnBack(Action onBackCallback)
        {
        }
    }
}