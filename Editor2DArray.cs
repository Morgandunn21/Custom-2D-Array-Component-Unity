using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class Editor2DArray
{
    public static void Display (SerializedProperty array2D,  GUIContent label)
    {
        array2D = array2D.FindPropertyRelative("array2D");
        //Get the property for the sidelength of the array
        SerializedProperty sideLength = array2D.FindPropertyRelative("Array.size");
        //Show the foldout for the array
        EditorGUILayout.PropertyField(array2D, label);
        //Indent the content in the foldout
        EditorGUI.indentLevel++;

        //if the foldout is expanded
        if(array2D.isExpanded)
        {
            //Show a field to change the side length
            EditorGUILayout.PropertyField(sideLength, new GUIContent("Side Length"));
            //for each row in the array
            for (int i = 0; i < array2D.arraySize; i++)
            {
                //get that row's serialized property
                SerializedProperty row = array2D.GetArrayElementAtIndex(i).FindPropertyRelative("row");

                if (row.arraySize != sideLength.intValue)
                {
                    //set the row's arraysize to be the same as the amount of rows
                    row.arraySize = sideLength.intValue;
                }

                EditorGUI.indentLevel++;

                //hold this rows values in a horizontal group
                EditorGUILayout.BeginHorizontal();
                //dont have any indent between the values
                int iLvl = EditorGUI.indentLevel;
                EditorGUI.indentLevel = 0;
                //for each value in the row
                for (int j = 0; j < row.arraySize; j++)
                {
                    //make a property field for the value
                    EditorGUILayout.PropertyField(row.GetArrayElementAtIndex(j), GUIContent.none, GUILayout.ExpandWidth(true), GUILayout.MinWidth(1f));
                }

                //reset the indents and end this horizontal group
                EditorGUI.indentLevel = iLvl;
                EditorGUILayout.EndHorizontal();
                EditorGUI.indentLevel--;
            }
        }
        
        EditorGUI.indentLevel--;
    }
}
