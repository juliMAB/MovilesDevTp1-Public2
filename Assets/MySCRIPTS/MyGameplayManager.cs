using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviourSingleton<MyGameManager>
{
    private static bool twoPlayers = false;
    private static bool tutorialInit = false;

    public static bool TwoPlayers { get => twoPlayers; set => twoPlayers = value; }
}
