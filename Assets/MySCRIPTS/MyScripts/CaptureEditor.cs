using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.TerrainAPI;
using UnityEngine;

[CustomEditor(typeof(capture))]
public class CaptureEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        capture c = (capture)target;

        if (GUILayout.Button("pick"))
        {
            c.takeShoot();
        }
    }
}
