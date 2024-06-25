using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class DataConverterWindow : EditorWindow
{

    [MenuItem("Kurma/Window")]
    public static void ShowWindow()
    {
        EditorWindow editorWindow = (DataConverterWindow)GetWindow(typeof(DataConverterWindow));
        editorWindow.minSize = new Vector2(600, 400);
        editorWindow.maxSize = new Vector2(800, 600);
    }
    public DataConverter _DataStaotage;

    public void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Scriptbale Object", EditorStyles.boldLabel);
        _DataStaotage = (DataConverter)EditorGUILayout.ObjectField(_DataStaotage, typeof(DataConverter), true);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Press"))
        {
            DataConvertAndSave();
        }
        EditorGUILayout.EndHorizontal();
    }

    void DataConvertAndSave()
    {

    }
}
