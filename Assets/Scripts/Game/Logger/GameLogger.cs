using UnityEngine;

namespace Platformer.Game.Logger
{
    public class GameLogger : IGameLogger
    {
        private const string Tag = nameof(GameLogger);

        public void Bootstrap()
        {
            Debug.Log($"{Tag} Bootstrap");
        }

        public void Log(string text)
        {
            Debug.Log($"{Tag} Log '{text}'");
        }
    }
}