using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(BuildingStrategy))]
public class BuildingStrategyEditor : Editor
{
    private SerializedProperty buildingsProperty;

    private void OnEnable()
    {
        buildingsProperty = serializedObject.FindProperty("Buildings");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(buildingsProperty, true);

        serializedObject.ApplyModifiedProperties();
    }
}
