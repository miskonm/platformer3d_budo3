using Platformer.Game.Enemy;
using UnityEditor;
using UnityEngine;

namespace Platformer.Game.Editor
{
    [CustomEditor(typeof(EnemySpawnPoint))]
    public class EnemySpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void DrawGizmo(EnemySpawnPoint component, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(component.transform.position, .5f);
        }
    }
}