using System;
using Platformer.Game.Logger;
using Platformer.Game.Logic;
using Platformer.Infrastructure.Persistent.Data;
using Platformer.Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth, ISaveLoadWriter
    {
        [SerializeField] private float _current;
        [SerializeField] private float _max;

        private IGameLogger _gameLogger;

        public event Action OnChanged;
        
        public float Current { get => _current; private set => _current = value; }
        public float Max { get => _max; private set => _max = value; }

        [Inject]
        public void Construct(IGameLogger gameLogger)
        {
            _gameLogger = gameLogger;
        }

        public void Setup(float current, float max)
        {
            Current = current;
            Max = max;

            // _gameLogger.Log($"Enemy setuped");
            OnChanged?.Invoke();
        }

        public void ApplyDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
            OnChanged?.Invoke();
        }

        public void Load(PersistentData persistentData)
        {
        }

        public void Save(PersistentData persistentData)
        {
        }
    }
}