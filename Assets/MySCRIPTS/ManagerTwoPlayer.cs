using System;
using UnityEngine;
    public enum GameStage
    {
        Intro,
        Game, 
        Camion=1,
        Deposit,
        Ninguno
    }
    public enum PjIndex
    {
        pj1,
        pj2
    }

public class ManagerTwoPlayer : MonoBehaviour
{

    [SerializeField] GameObject go_game;

    [SerializeField] Mediator[] mediator = null;

    [Serializable]
    struct PlayerData
    {
        public Camera[] cameras;
        [Header("init,camion,deposit")]
        public GameObject[] assets; //camion,deposito,init;

        public GameObject[] canvas;
    }
    [SerializeField] GameObject[] canvas1Player;

    [SerializeField] PlayerData[] playerData = null;

    public void Init(ref Action OnEndIntro)
    {
        IntroToIntro();
        if (MyGameplayManager.TwoPlayers)
        {
            mediator[(int)PjIndex.pj1].Subscribe<SceneChangedCommand>(ChangeScene);
            mediator[(int)PjIndex.pj2].Subscribe<SceneChangedCommand>(ChangeScene);
        }
        else
        {
            mediator[(int)PjIndex.pj1].Subscribe<SceneChangedCommand>(ChangeSceneOnePlayer);
            mediator[(int)PjIndex.pj2].gameObject.SetActive(false);
            SetAssetsAllOff(PjIndex.pj2);
        }
        OnEndIntro += IntroToGame;
    }

    private void IntroToIntro()
    {
        if (MyGameplayManager.TwoPlayers)
        {
            for (int i = 0; i < playerData[(int)PjIndex.pj1].cameras.Length; i++)
            {
                playerData[(int)PjIndex.pj1].cameras[i].rect = new Rect(new Vector2(0, 0), new Vector2(0.5f, 1.0f));
                playerData[(int)PjIndex.pj2].cameras[i].rect = new Rect(new Vector2(0.5f, 0), new Vector2(0.5f, 1.0f));
            }
            SetAssetsOn(PjIndex.pj2, GameStage.Intro);
        }
        else
        {
            SetCameraOn(PjIndex.pj2, GameStage.Ninguno);
            SetAssetsAllOff(PjIndex.pj2);
            SetCanvasOn(PjIndex.pj2, GameStage.Ninguno);
        }
    }

    public void IntroToGame()
    {
        go_game.SetActive(true);
        if (MyGameplayManager.TwoPlayers)
        {
            for (int i = 0; i < 2; i++)
            {
                SetCameraOn((PjIndex)i, GameStage.Camion);
                SetAssetsOn((PjIndex)i, GameStage.Camion);
                SetAssetsOn((PjIndex)i, GameStage.Deposit);
                SetCanvasOn((PjIndex)i, GameStage.Game);
            }
        }
        else
        {
            SetAssetsOn(PjIndex.pj1, GameStage.Camion);
            SetAssetsOn(PjIndex.pj1, GameStage.Deposit);
            SetCanvasOneOn(GameStage.Game);
            SetCameraOn(PjIndex.pj1, GameStage.Game);
        }
    }

    private void ChangeSceneOnePlayer(SceneChangedCommand c)
    {
        SetCanvasOneOn((GameStage)c.OnGoIndex);
        SetCameraOn((PjIndex)c.pjIndex, (GameStage)c.OnGoIndex);
    }

    private void ChangeScene(SceneChangedCommand c)
    {
        SetCameraOn((PjIndex)c.pjIndex, (GameStage)c.OnGoIndex);
        SetCanvasOn((PjIndex)c.pjIndex, (GameStage)c.OnGoIndex);
    }

    private void SetCameraOn(PjIndex ix,GameStage s)
    {
        for (int i = 0; i < playerData[(int)ix].cameras.Length; i++)
        {
            playerData[(int)ix].cameras[i].enabled = false;
            if (i == (int)s)
                playerData[(int)ix].cameras[i].enabled = true;
        }
    }
    private void SetCanvasOn(PjIndex ix, GameStage s)
    {
        for (int i = 0; i < playerData[(int)ix].canvas.Length; i++)
        {
            playerData[(int)ix].canvas[i].SetActive(false);
            if (i == (int)s)
                playerData[(int)ix].canvas[i].SetActive(true);
        }
    }
    private void SetAssetsOn(PjIndex ix, GameStage s)
    {
        playerData[(int)ix].assets[(int)s].SetActive(true);
    }
    private void SetAssetsOff(PjIndex ix, GameStage s)
    {
        playerData[(int)ix].assets[(int)s].SetActive(false);
    }
    private void SetAssetsAllOff(PjIndex ix)
    {
        for (int i = 0; i < playerData[(int)ix].assets.Length; i++)
        {
            playerData[(int)ix].assets[i].SetActive(false);
        }
    }
    private void SetCanvasOneOn(GameStage s)
    {
        for (int i = 0; i < canvas1Player.Length; i++)
            canvas1Player[i].SetActive(false);
        canvas1Player[(int)s].SetActive(true);
    }
}
