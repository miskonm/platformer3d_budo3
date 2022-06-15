using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Factory
{
    public interface IUiInternalFactory
    {
        T Create<T>(GameObject prefab, Transform under = null) where T : MonoBehaviour;
        T Create<T>(T prefab, Transform under = null) where T : MonoBehaviour;
        GameObject Create(GameObject prefab, Transform under = null);
    }
}