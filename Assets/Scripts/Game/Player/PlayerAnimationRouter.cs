using UnityEngine;

namespace Platformer.Game.Player
{
    public class PlayerAnimationRouter : MonoBehaviour
    {
        [SerializeField] private PlayerAttack _playerAttack;

        public void MeleeAttackEnd() =>
            _playerAttack.OnAttackFinished();

        public void MeleeAttackStart() { }
    }
}