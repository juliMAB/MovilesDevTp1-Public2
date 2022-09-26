using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class valueScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tex;
    [SerializeField] PjIndex pjIndex;

    public void Start()
    {
        changeTextToValue();
    }
    public void changeTextToValue()
    {
        switch (pjIndex)
        {
            case PjIndex.pj1:
                tex.text = GameManager.Get().score1.ToString();
                break;
            case PjIndex.pj2:
                tex.text = GameManager.Get().score2.ToString();
                break;
            default:
                break;
        }
        tex.color = Color.black;
    }
}

[CustomEditor(typeof(valueScore))]
public class valueScoreEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        valueScore value = (valueScore)target;

        if (GUILayout.Button("getValue"))
            value.changeTextToValue();

    }
}

