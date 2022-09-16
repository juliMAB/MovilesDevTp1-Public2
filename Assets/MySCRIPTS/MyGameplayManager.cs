using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MyGameplayManager : MonoBehaviourSingleton<MyGameplayManager>
{
    [SerializeField] Mediator[] mediator = null;

    [SerializeField] bool b_twoPlayers = false;

    private static bool twoPlayers = false;

    [SerializeField] IntroManager[] intro = null;

    [SerializeField] Action OnEndIntro;

    [SerializeField] GameObject[] go_intro;

    [SerializeField] GameObject go_game;

    [SerializeField] ManagerTwoPlayer ManagerTwo;

    [SerializeField] Timer timer;

    [SerializeField] float f_timeGame = 60;

    [SerializeField] float[] score = new float[2];

    private static int bagValue = 1;

    private FadeController m_fadeController;

    public static bool TwoPlayers { get => twoPlayers; set => twoPlayers = value; }
    public static int BagValue { get => bagValue; set => bagValue = value; }

    private void OnValidate()
    {
        twoPlayers = b_twoPlayers;
    }


    private void Start()
    {
        twoPlayers = GameManager.Get().two_players;
        FadeStart();
        ManagerTwo.Init(ref OnEndIntro);
        OnEndIntro += () => { go_game.SetActive(true); timer.Init(f_timeGame,()=> m_fadeController.FadeOut(1.0f, Color.black, EndGame));  ; };
        intro[0].Init(OnEndIntro);
        if (twoPlayers)
            intro[1].Init(OnEndIntro);
        go_game.SetActive(false);
        mediator[0].Subscribe<ScoreChangedCommand>(UpdateLocalScoreOne);
        if (twoPlayers)
            mediator[0].Subscribe<ScoreChangedCommand>(UpdateLocalScoreTwo);
    }

    private void EndGame()
    {
        GameManager.Get().score1 = score[0];
        GameManager.Get().score2 = score[0];
        GameManager.Get().LoadEnd();
    }
    private void UpdateLocalScoreOne(ScoreChangedCommand c)
    {
        score[0] = c.ScoreOnGlobal;
    }
    private void UpdateLocalScoreTwo(ScoreChangedCommand c)
    {
        score[1] = c.ScoreOnGlobal;
    }

    private void FadeStart()
    {

        m_fadeController = FadeController.Instance;
        m_fadeController.SetSortingOrder(1);
        m_fadeController.FadeIn(1.0f, Color.black);

        FadeController.Instance.FadeIn(1.0f);

    }
}
