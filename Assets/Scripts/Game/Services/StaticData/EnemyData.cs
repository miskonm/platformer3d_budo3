using Platformer.Game.Enemy;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Platformer.Game.Services.StaticData
{
    [CreateAssetMenu(fileName = Tag, menuName = "StaticData/Enemy")]
    public class EnemyData : ScriptableObject
    {
        private const string Tag = nameof(EnemyData);

        public EnemyType EnemyType;
        public float Hp;
        public AssetReferenceGameObject Reference;
    }
}