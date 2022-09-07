
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ManagerTwoPlayer : MonoBehaviour
{
    [SerializeField] Mediator[] mediator = null;

    [Serializable]
    struct Player
    {
        public Camera[] cameras;

        public GameObject[] assets; //camion,deposito,init;

        public GameObject[] canvas;
    }
    [SerializeField] GameObject[] canvas1Player;

    [SerializeField] Player[] playerData = null;

    public void Init()
    {
        if (MyGameplayManager.TwoPlayers)
        {
            for (int i = 0; i < playerData[0].cameras.Length; i++)
            {
                playerData[0].cameras[i].rect = new Rect(new Vector2(0, 0)   , new Vector2(0.5f, 1.0f));
                playerData[1].cameras[i].rect = new Rect(new Vector2(0.5f, 0), new Vector2(0.5f, 1.0f));
            }
        }
        else
        {
            for (int i = 0; i < playerData[1].cameras.Length; i++)
                playerData[1].cameras[i].enabled = false;
            for (int i = 0; i < playerData[1].assets.Length; i++)
                playerData[1].assets[i].SetActive(false);
            for (int i = 0; i < playerData[1].canvas.Length; i++)
                playerData[1].canvas[i].SetActive(false);
        }
    }

    public void IntroToGame()
    {
        if (MyGameplayManager.TwoPlayers)
        {
            for (int i = 0; i < playerData[0].cameras.Length; i++)
            {
                playerData[0].cameras[i].rect = new Rect(new Vector2(0, 0), new Vector2(0.5f, 1.0f));
                playerData[1].cameras[i].rect = new Rect(new Vector2(0.5f, 0), new Vector2(0.5f, 1.0f));
            }
            for (int i = 0; i < playerData[1].assets.Length; i++)
                playerData[1].assets[i].SetActive(true);
        }
        else
        {
            for (int i = 0; i < playerData[1].cameras.Length; i++)
                playerData[1].cameras[i].enabled = false;
            for (int i = 0; i < playerData[1].assets.Length; i++)
                playerData[1].assets[i].SetActive(false);
            for (int i = 0; i < playerData[1].canvas.Length; i++)
                playerData[1].canvas[i].SetActive(false);
        }
    }

    public void OldExample()
    {
        if (MyGameplayManager.TwoPlayers)
        {
            for (int i = 0; i < playerData[0].cameras.Length; i++)
            {
                playerData[0].cameras[i].rect = new Rect(new Vector2(0, 0), new Vector2(0.5f, 1.0f));
                playerData[1].cameras[i].rect = new Rect(new Vector2(0.5f, 0), new Vector2(0.5f, 1.0f));
            }
            for (int i = 0; i < playerData[1].assets.Length; i++)
                playerData[1].assets[i].SetActive(true);
            for (int i = 0; i < playerData[0].canvas.Length; i++)
            {
                playerData[0].canvas[i].SetActive(true);
                playerData[1].canvas[i].SetActive(true);
            }
            for (int i = 0; i < canvas1Player.Length; i++)
            {
                canvas1Player[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < playerData[1].cameras.Length; i++)
                playerData[1].cameras[i].enabled = false;
            for (int i = 0; i < playerData[1].assets.Length; i++)
                playerData[1].assets[i].SetActive(false);
            for (int i = 0; i < playerData[1].canvas.Length; i++)
            {
                playerData[0].canvas[i].SetActive(false);
                playerData[1].canvas[i].SetActive(false);
            }
            for (int i = 0; i < canvas1Player.Length; i++)
            {
                canvas1Player[i].SetActive(true);
            }
        }
    }

}
