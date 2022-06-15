using System.Collections.Generic;
using Platformer.Game.Services.Factory;
using Platformer.Infrastructure.Persistent.Data;
using Platformer.Infrastructure.SaveLoad;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Enemy
{
    public class EnemySpawner : MonoBehaviour, ISaveLoadWriter
    {
        public EnemyType EnemyType;
        public string Id;

        private IGameFactory _gameFactory;
        private EnemyDeath _enemyDeath;

        private bool _isKilled;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void OnDestroy()
        {
            if (_enemyDeath != null)
                _enemyDeath.OnDeath -= OnDead;
        }

        public void Save(PersistentData persistentData)
        {
            if (!_isKilled)
                return;

            List<string> killedEnemies = persistentData.LevelData.KilledEnemies;

            if (!killedEnemies.Contains(Id))
                killedEnemies.Add(Id);
        }

        public void Load(PersistentData persistentData)
        {
            List<string> killedEnemies = persistentData.LevelData.KilledEnemies;

            bool isContains = killedEnemies.Contains(Id);
            Debug.Log($"Spawner with id '{Id}' is killed '{isContains}'");
            if (!isContains)
                Spawn();
            else
                _isKilled = true;
        }

        private async void Spawn()
        {
            GameObject enemy = await _gameFactory.CreateEnemy(EnemyType, at: transform.position, Id);
            if (enemy == null)
                return;

            _enemyDeath = enemy.GetComponentInChildren<EnemyDeath>();
            _enemyDeath.OnDeath += OnDead;
        }

        private void OnDead()
        {
            _enemyDeath.OnDeath -= OnDead;
            _isKilled = true;
        }
    }
}