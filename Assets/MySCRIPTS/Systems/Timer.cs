using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_time;
    private Action OnEndTimer;

    public float LocalTime { get => m_time; set => m_time = value; }

    public void Init(float time,Action OnEndTimer)
    {
        m_time = time;
        this.OnEndTimer = OnEndTimer;
        StartCoroutine(counter());
    }

    private IEnumerator counter()
    {
        float f_totalTime = m_time;
        while (m_time>0)
        {
            yield return null;
            m_time -= Time.deltaTime;
        }
        OnEndTimer?.Invoke();
    }
}
