using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Platformer.Game.Services.Assets
{
    public interface IAssetsService
    {
        UniTask<GameObject> Instantiate(AssetReferenceGameObject enemyDataReference);
        void Clean();
    }
}