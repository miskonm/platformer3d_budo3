using DG.Tweening;
using UnityEngine;

namespace Platformer.Game.Utility.Animations
{
    public class IntervalAnimatable : BaseAnimatable
    {
        [SerializeField] private float _delay;
        
        public override Tween Begin() =>
            DOVirtual.DelayedCall(_delay, null);

        public override void Kill()
        {
        }
    }
}