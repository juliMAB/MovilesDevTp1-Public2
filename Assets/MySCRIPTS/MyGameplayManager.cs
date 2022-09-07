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

    public static bool TwoPlayers { get => twoPlayers; set => twoPlayers = value; }

    private void OnValidate()
    {
        twoPlayers = b_twoPlayers;
    }


    public void Start()
    {
        OnEndIntro += TestCall;
        intro[0].Init(OnEndIntro);
        if(twoPlayers)
        {
           ManagerTwo.Init();
           intro[1].Init(OnEndIntro);
        }
        go_game.SetActive(false);
    }

    private void TestCall()
    {
        //prenderGame
        go_game.SetActive(true);
        //apagarIntro;
        go_intro[0].SetActive(false);
        if(twoPlayers)
        {
            go_intro[1].SetActive(false);
        }
    }
}
