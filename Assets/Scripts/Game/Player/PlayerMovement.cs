using Platformer.Game.Input;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private CharacterController _controller;

        [Header("Move Settings")]
        [SerializeField] private float _speed = 3f;

        [Header("Gravity Settings")]
        [SerializeField] private float _gravityMultiplier = 1f;

        [Header("Ground Detect")]
        [SerializeField] private Transform _groundCheckTransform;
        [SerializeField] private float _groundCheckRadius = 0.2f;
        [SerializeField] private LayerMask _groundCheckLayerMask;

        [Header("Jump")]
        [SerializeField] private float _jumpHeight = 2f;

        private IInputService _inputService;

        private Transform _cachedTransform;
        private Vector3 _fallVector;

        public Vector3 Velocity { get; private set; }
        public bool IsGrounded { get; private set; }
        public float VerticalVelocity { get; private set; }

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            Vector2 moveAxis = _inputService.MoveAxis;

            Vector3 moveVector = _cachedTransform.right * moveAxis.x + _cachedTransform.forward * moveAxis.y;
            Velocity = moveVector * _speed;
            _controller.Move(Velocity * Time.deltaTime);

            IsGrounded =
                Physics.CheckSphere(_groundCheckTransform.position, _groundCheckRadius, _groundCheckLayerMask);

            if (IsGrounded && _fallVector.y < 0)
                _fallVector.y = 0;

            float gravity = Physics.gravity.y * _gravityMultiplier;

            if (_inputService.IsJump && IsGrounded)
            {
                _fallVector.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
            }

            _fallVector.y += gravity * Time.deltaTime;
            _controller.Move(_fallVector * Time.deltaTime);
            VerticalVelocity = _fallVector.y;
        }
    }
}