using UnityEditor;
using UnityEngine;

/// <summary>
/// Use [ReadOnly] as an attribute on class fields to disable editing
/// </summary>
/// <see cref="https://www.youtube.com/watch?v=r3nwTGLHygI"/>
public class ReadOnlyAttribute : PropertyAttribute
{
}

[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyPropertyDrawer : PropertyDrawer//, ISerializationCallbackReceiver
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label);
        GUI.enabled = true;
    }
}