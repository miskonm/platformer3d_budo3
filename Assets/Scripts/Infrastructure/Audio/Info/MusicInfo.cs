using System;

namespace Platformer.Infrastructure.Audio.Info
{
    [Serializable]
    public class MusicInfo : AudioInfo
    {
        public MusicType Type;

        public override void OnValidate()
        {
            base.OnValidate();
            name = Type.ToString();
        }
    }
}