using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] BolsaMoveAnim bolsaMove;

    [SerializeField] bool playerCheck = false;

    [SerializeField] Action<bool> OnEndInit = null;

    public void Init(ref Action endIntro)
    {
        bolsaMove.Init( ref endIntro, 1);
    }

    private void CallEndInit()
    {
        OnEndInit
    }

    public bool EndInit()
    {
        if (MyGameManager.TwoPlayers)
            if (playerCheck == false) 
                playerCheck = true; 
            else
                return true;
        else
            return true;
        return false;
    }

    private void UpdateThis()
    {
        OnEndInit = EndInit();
    }

}
