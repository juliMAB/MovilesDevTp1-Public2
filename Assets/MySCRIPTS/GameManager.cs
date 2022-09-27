using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public bool two_players = false;

    public float score1 = 0;

    public float score2 = 0;

    public int dificulty = 0;

    public void LoadGame() => SceneManager.LoadScene("Game2");

    public void LoadEnd() => SceneManager.LoadScene("End");

    public void LoadMenu() => SceneManager.LoadScene("Menu");

    public void Quit() => Application.Quit();
}
