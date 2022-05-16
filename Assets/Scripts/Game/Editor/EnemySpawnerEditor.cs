using Platformer.Game.Enemies;
using UnityEditor;
using UnityEngine;

namespace Platformer.Game.Editor
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void DrawGizmo(EnemySpawner component, GizmoType gizmoType)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(component.transform.position, .5f);
        }
    }
}