using DG.Tweening;
using UnityEngine;

namespace Platformer.Game.Utility.Animations
{
    public abstract class BaseAnimatable : MonoBehaviour
    {
        public abstract Tween Begin();
        public abstract void Kill();
    }
}