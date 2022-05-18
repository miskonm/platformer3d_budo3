using UnityEngine;

namespace Platformer.Game.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimation : MonoBehaviour
    {
        private static readonly int Velocity = Animator.StringToHash("Velocity");
        private static readonly int IsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        private static readonly int Attack = Animator.StringToHash("Attack");

        [SerializeField] private Animator _animator;

        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            _animator.SetFloat(Velocity, _playerMovement.Velocity.magnitude);
            _animator.SetFloat(VerticalVelocity, _playerMovement.VerticalVelocity);
            _animator.SetBool(IsGrounded, _playerMovement.IsGrounded);
        }

        public void PlayAttack() =>
            _animator.SetTrigger(Attack);
    }
}