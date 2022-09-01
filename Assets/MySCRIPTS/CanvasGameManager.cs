using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasGameManager : MonoBehaviour
{
    [SerializeField] Mediator mediator;

    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        mediator.Subscribe<ScoreChangedCommand>(ScoreChangeUI);
    }

    void ScoreChangeUI(ScoreChangedCommand c)
    {
        text.text = "Truck: " + c.ScoreOnTruck.ToString();
    }
}
