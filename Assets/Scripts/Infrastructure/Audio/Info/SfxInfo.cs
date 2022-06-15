using System;

namespace Platformer.Infrastructure.Audio.Info
{
    [Serializable]
    public class SfxInfo : AudioInfo
    {
        public SfxType Type;
        
        public override void OnValidate()
        {
            base.OnValidate();

            name = Type.ToString();
        }
    }
}