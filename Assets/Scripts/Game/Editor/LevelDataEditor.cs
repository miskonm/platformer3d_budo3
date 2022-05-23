using System.Linq;
using Platformer.Game.Enemy;
using Platformer.Game.Objects;
using Platformer.Game.Services.StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.Game.Editor
{
    [CustomEditor(typeof(LevelData))]
    public class LevelDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelData levelData = (LevelData) target;

            if (GUILayout.Button("Get Info"))
            {
                levelData.LevelName = SceneManager.GetActiveScene().name;

                levelData.EnemySpawnPoints = FindObjectsOfType<EnemySpawnPoint>()
                    .Select(x => new EnemySpawnData(x.EnemyType, x.transform.position, x.GetComponent<UniqueId>().Id))
                    .ToList();

                EditorUtility.SetDirty(levelData);
                AssetDatabase.SaveAssets();
            }
        }
    }
}