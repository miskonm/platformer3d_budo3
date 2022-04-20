namespace Platformer.Game.Logger
{
    public interface IGameLogger
    {
        void Bootstrap(); //TODO: Async
        void Log(string text);
    }
}