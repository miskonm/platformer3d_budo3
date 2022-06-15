using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Platformer.Infrastructure.Assets
{
    public interface IResourcesAssetsService
    {
        UniTask<T> GetAsset<T>(string path) where T : Object;
    }
}