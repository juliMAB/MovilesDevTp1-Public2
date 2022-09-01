using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasGameManager : MonoBehaviour
{
    [SerializeField] Mediator mediator;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI text2;

    private void Start()
    {
        mediator.Subscribe<ScoreChangedCommand>(ScoreChangeUI);
    }

    void ScoreChangeUI(ScoreChangedCommand c)
    {
        text.text = "Truck: " + c.ScoreOnTruck.ToString();
        text2.text = "Total: " + c.ScoreOnGlobal.ToString();
    }


}
