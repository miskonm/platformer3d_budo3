using System;
using DG.Tweening;
using NaughtyAttributes;
using Platformer.Game.Utility.Animations;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class DoorOpenButton : MonoBehaviour
    {
        [Header("Animation Settings")]
        [SerializeField] private V3AnimationInfo _startPositionInfo;
        [SerializeField] private V3AnimationInfo _endPositionInfo;
        [SerializeField] private float _delayBeforeStart = 1f;

        [Header("External Components")]
        [SerializeField] private Door _door;
        [SerializeField] private BaseAnimatable _baseAnimatable;
        
        private Tween _tween;
        private bool _isPressed;
        

        [Button()]
        private void Enter()
        {
            _tween?.Kill();

            _tween = transform
                .DOMove(_endPositionInfo.Value, _endPositionInfo.Duration)
                .SetEase(_endPositionInfo.Ease)
                .OnComplete(Open);
        }

        [Button()]
        private void Exit()
        {
            _tween?.Kill();

            Sequence sequence = DOTween.Sequence();
            
            if (_isPressed)
                sequence.AppendInterval(_delayBeforeStart);
            
            sequence.Append(transform
                .DOMove(_startPositionInfo.Value, _startPositionInfo.Duration)
                .SetEase(_startPositionInfo.Ease));
            sequence.OnComplete(Close);

            _tween = sequence;
        }

        private void Close()
        {
            _isPressed = false;
            _door.Close();
        }

        private void Open()
        {
            _isPressed = true;
            _door.Open();
        }
    }
}