using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Platformer.Infrastructure.Audio.Info
{
    [Serializable]
    public abstract class AudioInfo
    {
        [HideInInspector]
        public string name;
        [Range(0, 1f)]
        public float Volume = 1f;
        public string Path;
#if UNITY_EDITOR
        [SerializeField] private AudioClip Clip;
#endif
        public virtual void OnValidate()
        {
#if UNITY_EDITOR
            Path = Clip != null ? AssetDatabase.GetAssetPath(Clip) : string.Empty;
#endif
        }
    }
}