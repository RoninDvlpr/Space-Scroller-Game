using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("Y position of spawned objects (spawningYPosition) and Number of lines (numberOfLines) are hardcoded inside this script, because this parameters aren't going to change in the future",
            MessageType.Warning);

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Y spawn position", EditorStyles.boldLabel);
        EditorGUILayout.LabelField(Spawner.spawningYPosition.ToString());
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Number of lines", EditorStyles.boldLabel);
        EditorGUILayout.LabelField(Spawner.numberOfLines.ToString());
        GUILayout.EndHorizontal();
        
        base.OnInspectorGUI();
    }
}
