using DG.Tweening;
using UnityEngine;

namespace Platformer.Game.Utility.Animations
{
    public class V3LocalPositionAnimatable : BaseAnimatable
    {
        [SerializeField] private V3AnimationInfo _info;
        
        public override Tween Begin() =>
            transform.DOLocalMove(_info.Value, _info.Duration).SetEase(_info.Ease);

        public override void Kill()
        {
        }
    }
}