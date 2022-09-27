using UnityEditor;
using UnityEngine;


#if UNITY_EDITOR

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
#endif
