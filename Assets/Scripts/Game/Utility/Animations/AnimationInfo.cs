using System;
using DG.Tweening;
using UnityEngine;

namespace Platformer.Game.Utility.Animations
{
    [Serializable]
    public abstract class AnimationInfo<TValue>
    {
        public TValue Value;
        public float Duration;
        public Ease Ease = Ease.Linear;
    }

    [Serializable]
    public class V3AnimationInfo : AnimationInfo<Vector3>
    {
    }
    
    [Serializable]
    public class V2AnimationInfo : AnimationInfo<Vector2>
    {
    }
    
    [Serializable]
    public class FloatAnimationInfo : AnimationInfo<float>
    {
    }
}