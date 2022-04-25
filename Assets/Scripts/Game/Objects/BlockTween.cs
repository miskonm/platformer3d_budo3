using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace Platformer.Game.Objects
{
    public class BlockTween : MonoBehaviour
    {
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private float _moveToEndDuration = 2f;
        [SerializeField] private float _moveToStartDuration = 2f;
        [SerializeField] private float _endPositionDelay = 1f;
        [SerializeField] private float _startPositionDelay = .3f;

        private Tween _moveTween;

        private void Awake()
        {
            StartAnimation();
        }

        [Button()]
        private void StartAnimation()
        {
            Sequence sequence = DOTween.Sequence().SetLoops(-1);
            sequence.Append(transform.DOMove(_endPosition, _moveToEndDuration));
            sequence.AppendInterval(_endPositionDelay);
            sequence.Append(transform.DOMove(_startPosition, _moveToStartDuration));
            sequence.AppendInterval(_startPositionDelay);
            
            _moveTween = sequence;
        }

        [Button()]
        private void Kill()
        {
            _moveTween.Kill();
        }
    }
}