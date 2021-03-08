using ARVR.Collections;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(SerializableDictionary))]
public class SerializableDictionaryEditor : Editor
{
    private ReorderableList list;

    private readonly int labelWidth = 50;
    private readonly int keyPropertyWidth = 200;
    private readonly int valuePropertyWidth = 400;
    private readonly int propertyHorizontalSeparator = 10;

    public void OnEnable()
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty("entries"), true, true, true, true);
        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            
            EditorGUI.LabelField(new Rect(rect.x, rect.y, labelWidth, EditorGUIUtility.singleLineHeight), "Key");
            EditorGUI.PropertyField(new Rect(rect.x + labelWidth, rect.y, keyPropertyWidth, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("key"), GUIContent.none);

            EditorGUI.LabelField(new Rect(rect.x + labelWidth + keyPropertyWidth + propertyHorizontalSeparator, rect.y, labelWidth, EditorGUIUtility.singleLineHeight), "Value");
            EditorGUI.PropertyField(new Rect(rect.x + 2 * labelWidth + keyPropertyWidth + propertyHorizontalSeparator, rect.y, valuePropertyWidth, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("value"), GUIContent.none);
        };

        list.onAddCallback = (ReorderableList list) =>
        {
            int index = list.serializedProperty.arraySize;
            list.serializedProperty.arraySize++;
            list.index = index;

            // Important! When adding a new element to the list (and dictionary),
            // the newly created key must be unique.
            SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
            element.FindPropertyRelative("key").stringValue = System.Guid.NewGuid().ToString(); // Create some kind of unique key, like a GUID or adding a number to the last one.
        };

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        list.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}