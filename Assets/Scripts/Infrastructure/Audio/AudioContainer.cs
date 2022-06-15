using System;
using System.Collections.Generic;
using Platformer.Infrastructure.Audio.Info;
using UnityEngine;

namespace Platformer.Infrastructure.Audio
{
    [CreateAssetMenu(fileName = nameof(AudioContainer), menuName = "Audio/AudioContainer")]
    public class AudioContainer : ScriptableObject
    {
        public MusicInfo[] AllMusic;
        public SfxInfo[] AllSfx;

        private readonly Dictionary<SfxType, SfxInfo> _sfxCache = new Dictionary<SfxType, SfxInfo>();

        private void OnEnable()
        {
            //TODO: Setup dict
        }

        private void OnValidate()
        {
            if (AllMusic != null)
            {
                foreach (MusicInfo info in AllMusic)
                {
                    info.OnValidate();
                }
            }

            if (AllMusic != null)
            {
                foreach (SfxInfo info in AllSfx)
                {
                    info.OnValidate();
                }
            }
        }

        public SfxInfo Info(SfxType type) =>
            _sfxCache.TryGetValue(type, out SfxInfo info) ? info : null;

        public MusicInfo Info(MusicType musicType)
        {
            throw new NotImplementedException();
        }
    }
}