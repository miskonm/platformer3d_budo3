namespace Platformer.Infrastructure.SaveLoad.IO
{
    public interface ISaveLoadIO
    {
        T Read<T>(string key) where T : new();
        void Write<T>(T obj, string key);
    }
}