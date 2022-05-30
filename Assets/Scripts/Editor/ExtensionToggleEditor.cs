using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

[CustomEditor(typeof(ExtensionToggle))]
public class ExtensionToggleEditor : ToggleEditor
{
    public override void OnInspectorGUI()
    {
        ExtensionToggle extensionToggle = (ExtensionToggle)target;

        var prevColor = GUI.color;
        GUI.color = Color.green;
        extensionToggle.extension = EditorGUILayout.TextField("Extension", extensionToggle.extension);
        GUI.color = prevColor;
        GUILayout.Space(10);
        base.OnInspectorGUI();
    }
}