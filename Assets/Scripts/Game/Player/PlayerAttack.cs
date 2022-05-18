using Platformer.Game.Input;
using Platformer.Game.Logic;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float _damage = 2; // TODO: Static data

        [SerializeField] private PlayerAnimation _animation;
        [SerializeField] private Hitter _hitter;

        private IInputService _inputService;

        private bool _isAttacking; // TODO: Update animator and do it there

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void OnEnable()
        {
            _hitter.OnHit += OnHit;
        }

        private void OnDisable()
        {
            _hitter.OnHit -= OnHit;
        }

        private void Update()
        {
            if (_inputService.IsAttackUp && !_isAttacking)
                Attack();
        }

        public void OnAttackFinished() =>
            _isAttacking = false;

        private void OnHit(Collider other)
        {
            if (!_isAttacking)
                return;
            
            if (other.CompareTag(Tags.Enemy))
            {
                other.gameObject.GetComponent<IHealth>().ApplyDamage(_damage);
            }
        }

        private void Attack()
        {
            _isAttacking = true;
            _animation.PlayAttack();
        }
    }
}