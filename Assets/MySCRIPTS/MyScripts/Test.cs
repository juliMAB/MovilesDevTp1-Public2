using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject visualBolsa;
    public void DeleteVisual()
    {
        List<GameObject> toDelete = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
                GameObject bolsa = transform.GetChild(i).gameObject;
                for (int w = 0; w < bolsa.transform.childCount; w++)
                    if (bolsa.transform.GetChild(w).gameObject.name.StartsWith("Visual"))
                        toDelete.Add (bolsa.transform.GetChild(w).gameObject);
        }
        for (int i = 0; i < toDelete.Count; i++)
        {
            if (toDelete == null)
                continue;
            toDelete[i].transform.parent = null;
            DestroyImmediate(toDelete[i]);
        }
    }
    public void AddVisual()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
                GameObject bolsa = transform.GetChild(i).gameObject;
                GameObject visual = Instantiate(visualBolsa, bolsa.transform);
                visual.transform.localPosition = Vector3.zero;
        }
    }
}

[CustomEditor(typeof(Test))]
public class TestEdit: Editor
{
    public override void OnInspectorGUI()
    {

        Test test = (Test)target;
        base.OnInspectorGUI();
        if(GUILayout.Button("delet Visuals"))
        {
            test.DeleteVisual();
        }
        if (GUILayout.Button("Add Visuals"))
        {
            test.AddVisual();
        }
    }
}
