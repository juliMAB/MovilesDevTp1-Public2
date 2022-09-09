using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerText : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] TextMeshProUGUI timeText;

    int lastFrameTime;
    void Update()
    {
        int currentTime = ((int)Math.Round(timer.LocalTime));
        if (lastFrameTime == currentTime)
            return;
        timeText.text = currentTime.ToString();
        lastFrameTime = currentTime;
    }
}
