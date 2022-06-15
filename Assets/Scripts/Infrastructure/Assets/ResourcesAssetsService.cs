using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Platformer.Infrastructure.Assets
{
    public class ResourcesAssetsService : IResourcesAssetsService
    {
        public async UniTask<T> GetAsset<T>(string path) where T : Object =>
            await Resources.LoadAsync<T>(path).ToUniTask() as T;
    }
}