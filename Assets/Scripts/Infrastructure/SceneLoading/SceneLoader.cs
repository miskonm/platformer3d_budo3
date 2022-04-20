using Zenject;

namespace Platformer.Infrastructure.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        private ZenjectSceneLoader _sceneLoader;

        public SceneLoader(ZenjectSceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void LoadScene(string sceneName) =>
            _sceneLoader.LoadScene(sceneName);

        // public async void LoadSceneAsync(string sceneName)
        // {
        //     await _sceneLoader.LoadSceneAsync(sceneName);
        // }
    }
}