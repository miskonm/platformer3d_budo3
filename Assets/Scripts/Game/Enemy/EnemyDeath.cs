using System;
using UnityEngine;

namespace Platformer.Game.Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        private EnemyHealth _enemyHealth;

        public event Action OnDeath;

        public bool IsDead { get; private set; }

        private void Awake()
        {
            _enemyHealth = GetComponent<EnemyHealth>();
            _enemyHealth.OnChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            _enemyHealth.OnChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (_enemyHealth.Current > 0)
                return;

            Die();
        }

        private void Die()
        {
            // TODO: Spawn death particles
            // TODO: Spawn loot
            Destroy(gameObject);
            
            IsDead = true;
            OnDeath?.Invoke();
        }
    }
}