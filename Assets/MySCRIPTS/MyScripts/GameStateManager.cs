using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum GameState
    {
        Gameplay,
        Pause
    }
public class GameStateManager : MonoBehaviourSingleton<GameStateManager>
{
    public GameState CurrentGameState;

    public delegate void GameStateChangeHandler(GameState newGameState);
    public event GameStateChangeHandler OnGameStateChanged;

    public void SetState(GameState newGameState)
    {
        if (newGameState == CurrentGameState)
            return;

        CurrentGameState = newGameState;
        OnGameStateChanged?.Invoke(newGameState);
    }

    public void TooglePause()
    {
        switch (CurrentGameState)
        {
            case GameState.Gameplay:
                SetState(GameState.Pause);
                break;
            case GameState.Pause:
                SetState(GameState.Gameplay);
                break;
            default:
                break;
        }
        
    }
}
