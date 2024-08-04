using System.Collections;
using System.Collections.Generic;
using SlotMachine.Settings;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (Level)target;

        if (GUILayout.Button("Save", GUILayout.Height(40)))
        {
            script.Save();
        }

    }
}