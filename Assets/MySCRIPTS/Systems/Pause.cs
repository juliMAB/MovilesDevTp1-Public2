using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    bool pause = false;
    public UnityEvent<bool> OnClick;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
            OnClick?.Invoke(pause);

            GameState currentGameState = GameStateManager.Get().CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Pause
                : GameState.Gameplay;
            GameStateManager.Get().SetState(newGameState);

        }
    }
}
