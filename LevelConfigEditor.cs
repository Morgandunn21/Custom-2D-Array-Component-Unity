using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelConfig))]
public class LevelConfigEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("levelName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cubeColors"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("colorPalette"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("turnLimit"), true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("timeLimit"));

        Editor2DArray.Display(serializedObject.FindProperty("config"), new GUIContent("Level Config"));

        serializedObject.ApplyModifiedProperties();
    }
}
