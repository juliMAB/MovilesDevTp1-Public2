using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameplayManager : MonoBehaviourSingleton<MyGameplayManager>
{
    [SerializeField] bool b_twoPlayers = false;

    private static bool twoPlayers = false;

    [SerializeField] IntroManager[] intro = null;

    [SerializeField] Action OnEndIntro;

    [SerializeField] GameObject[] go_intro;

    [SerializeField] GameObject go_game;

    [SerializeField] ManagerTwoPlayer ManagerTwo;

    private static int bagValue = 1;

    public static bool TwoPlayers { get => twoPlayers; set => twoPlayers = value; }
    public static int BagValue { get => bagValue; set => bagValue = value; }

    private void OnValidate()
    {
        twoPlayers = b_twoPlayers;
    }


    public void Start()
    {
        ManagerTwo.Init(ref OnEndIntro);
        OnEndIntro +=()=> { go_game.SetActive(true); };
        intro[0].Init(OnEndIntro);
        if(twoPlayers)
           intro[1].Init(OnEndIntro);
        go_game.SetActive(false);
    }
}
