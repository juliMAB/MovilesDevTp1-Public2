using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float m_time;
    private Action OnEndTimer;

    float f_totalTime=99999;
    public float LocalTime { get => f_totalTime; }

    public void Init(float time,Action OnEndTimer)
    {
        m_time = time;
        f_totalTime = m_time;
        this.OnEndTimer = OnEndTimer;
        GameStateManager.Get().OnGameStateChanged += OnGameStateChanged;

    }

    private void Update()
    {
#if UNITY_EDITOR|| UNITY_STANDALONE_WIN
        if (Input.GetKey(KeyCode.V))
            f_totalTime -= 10;

#endif
        if (f_totalTime > 0)
        {
            f_totalTime -= Time.deltaTime;
            return;
        }
        else
        {
            OnEndTimer?.Invoke();
            this.enabled = false;
        }
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        if (newGameState == GameState.Gameplay)
        {
            enabled = true;
        }
        else
        enabled = false ;
    }

    private void reset()
    {
        f_totalTime = m_time;
    }
}
