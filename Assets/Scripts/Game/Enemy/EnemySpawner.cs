using Platformer.Game.Services.Factory;
using UnityEngine;
using Zenject;

namespace Platformer.Game.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        public EnemyType EnemyType;

        private IGameFactory _gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Spawn()
        {
            _gameFactory.CreateEnemy(EnemyType, at: transform.position);
        }
    }
}