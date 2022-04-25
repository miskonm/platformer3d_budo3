using DG.Tweening;
using Platformer.Game.Utility.Animations;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class Door : MonoBehaviour
    {
        [Header("Animation Settings")]
        [SerializeField] private V3AnimationInfo _startPositionInfo;
        [SerializeField] private V3AnimationInfo _endPositionInfo;

        private Tween _tween;

        public void Open()
        {
            _tween?.Kill();
            _tween = Move(_endPositionInfo);
        }

        public void Close()
        {
            _tween?.Kill();
            _tween = Move(_startPositionInfo);
        }

        private Tween Move(V3AnimationInfo info) =>
            transform.DOLocalMove(info.Value, info.Duration).SetEase(info.Ease);
    }
}