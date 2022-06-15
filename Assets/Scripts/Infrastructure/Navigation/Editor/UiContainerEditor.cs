using Platformer.Infrastructure.Navigation.Container;
using UnityEditor;

namespace Platformer.Infrastructure.Navigation.Editor
{
    [CustomEditor(typeof(UiContainer))]
    public class UiContainerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            UiContainer container = (UiContainer) target;
            container.EditorUpdate();

            serializedObject.ApplyModifiedProperties();
        }
    }
}