using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool two_players = false;

    public static float score1 = 0;

    public static float score2 = 0;

    public static void LoadGame() => SceneManager.LoadScene("Game");

    public static void LoadEnd() => SceneManager.LoadScene("End");

    public static void LoadMenu() => SceneManager.LoadScene("Menu");
}
