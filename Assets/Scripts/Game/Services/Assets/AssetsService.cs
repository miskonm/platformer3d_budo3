using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Platformer.Game.Services.Assets
{
    public class AssetsService : IAssetsService
    {
        private Dictionary<AssetReferenceGameObject, GameObject> _prefabsCache =
            new Dictionary<AssetReferenceGameObject, GameObject>();

        private List<AssetReferenceGameObject> _loadingReferences = new List<AssetReferenceGameObject>();

        private Dictionary<AssetReferenceGameObject, List<GameObject>> _instances =
            new Dictionary<AssetReferenceGameObject, List<GameObject>>();

        public async UniTask<GameObject> Instantiate(AssetReferenceGameObject enemyDataReference)
        {
            if (!_prefabsCache.ContainsKey(enemyDataReference))
            {
                if (_loadingReferences.Contains(enemyDataReference))
                {
                    await UniTask.WaitUntil(() => !_loadingReferences.Contains(enemyDataReference));
                }
                else
                {
                    await PreloadHandle(enemyDataReference);
                }
            }

            GameObject gameObject = await enemyDataReference.InstantiateAsync().ToUniTask();

            if (!_instances.ContainsKey(enemyDataReference))
            {
                _instances.Add(enemyDataReference, new List<GameObject>());
            }

            _instances[enemyDataReference].Add(gameObject);

            return gameObject;
        }

        public void Clean()
        {
            foreach (AssetReferenceGameObject assetReferenceGameObject in _prefabsCache.Keys)
            {
                List<GameObject> gameObjects = _instances[assetReferenceGameObject];
                foreach (GameObject go in gameObjects)
                {
                    assetReferenceGameObject.ReleaseInstance(go);
                }

                assetReferenceGameObject.ReleaseAsset();
            }

            _instances.Clear();
            _prefabsCache.Clear();
        }

        private async UniTask PreloadHandle(AssetReferenceGameObject enemyDataReference)
        {
            _loadingReferences.Add(enemyDataReference);
            GameObject prefab = await enemyDataReference.LoadAssetAsync().ToUniTask();
            _loadingReferences.Remove(enemyDataReference);
            _prefabsCache[enemyDataReference] = prefab;
        }
    }
}