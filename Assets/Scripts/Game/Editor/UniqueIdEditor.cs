using Platformer.Game.Objects;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Platformer.Game.Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            UniqueId uniqueId = (UniqueId) target;

            if (Application.isPlaying)
                return;

            if (IsSet(uniqueId))
                return;

            uniqueId.GenerateId();

            EditorUtility.SetDirty(uniqueId);
            EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
        }

        private bool IsSet(UniqueId uniqueId) =>
            !string.IsNullOrEmpty(uniqueId.Id);
    }
}