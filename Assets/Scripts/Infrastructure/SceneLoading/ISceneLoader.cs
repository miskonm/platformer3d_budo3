using Cysharp.Threading.Tasks;

namespace Platformer.Infrastructure.SceneLoading
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string sceneName);
    }
}