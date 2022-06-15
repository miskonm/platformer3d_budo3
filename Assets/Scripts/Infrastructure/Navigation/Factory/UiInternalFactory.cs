using UnityEngine;
using Zenject;

namespace Platformer.Infrastructure.Navigation.Factory
{
    public class UiInternalFactory : IUiInternalFactory
    {
        private readonly DiContainer _diContainer;

        public UiInternalFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Create<T>(GameObject prefab, Transform under = null) where T : MonoBehaviour
        {
            GameObject gameObject = Create(prefab);
            return gameObject.GetComponentInChildren<T>();
        }

        public T Create<T>(T prefab, Transform under = null) where T : MonoBehaviour =>
            _diContainer.InstantiatePrefabForComponent<T>(prefab.gameObject, under);

        public GameObject Create(GameObject prefab, Transform under = null) =>
            _diContainer.InstantiatePrefab(prefab, under);
    }
}