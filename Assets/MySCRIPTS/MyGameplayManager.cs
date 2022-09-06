using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameplayManager : MonoBehaviourSingleton<MyGameplayManager>
{
    [SerializeField] bool b_twoPlayers = false;

    private static bool twoPlayers = false;

    [SerializeField] IntroManager intro;

    [SerializeField] Action OnEndIntro;

    [SerializeField] GameObject go_intro;

    [SerializeField] GameObject go_game;

    public static bool TwoPlayers { get => twoPlayers; set => twoPlayers = value; }

    private void OnValidate()
    {
        twoPlayers = b_twoPlayers; 
    }


    public void Start()
    {
        OnEndIntro += TestCall;
        intro.Init(OnEndIntro);
    }

    private void TestCall()
    {
        //prenderGame
        go_game.SetActive(true);
        //apagarIntro;
        go_intro.SetActive(false);
    }
}
