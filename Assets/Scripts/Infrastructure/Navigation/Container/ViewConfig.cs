using System;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Platformer.Infrastructure.Navigation.Container
{
    [Serializable]
    public class ViewConfig
    {
        [HideInInspector]
        [SerializeField] private string _name;
        public string Path;
#if UNITY_EDITOR
        public GameObject Prefab;
#endif
        public virtual void OnValidate()
        {
#if UNITY_EDITOR
            Path = GetResourcesPath();
            
            SetGameObject(Prefab);
            _name = GetName();
#endif
        }

        protected virtual void SetGameObject(GameObject gameObject) { }

        private string GetResourcesPath()
        {
            if (Prefab == null)
                return string.Empty;

            string assetPath = AssetDatabase.GetAssetPath(Prefab);
            if(assetPath.IndexOf("Resources") > -1)
            {
                assetPath = assetPath.Substring(assetPath.LastIndexOf("Resources/") + 10);
                return assetPath.Substring(0, assetPath.LastIndexOf("."));
            }
            
            UnityEngine.Debug.LogError("Not an object in a resources folder.");
            return string.Empty;
        }

        private string GetName()
        {
            if (string.IsNullOrEmpty(Path))
                return string.Empty;

            string[] split = Path.Split('/');
            return split[split.Length - 1];
        }
    }
}