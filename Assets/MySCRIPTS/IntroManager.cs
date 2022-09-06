using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] BolsaMoveAnim bolsaMove;

    [SerializeField] bool playerCheck = false;

    [SerializeField] Action OnEndIntro = null;

    [SerializeField] Action OnChangeBolsa = null;

    public void Init( Action OnEndIntro)
    {
        this.OnEndIntro = OnEndIntro;
        OnChangeBolsa += isChangeEnd; 
        bolsaMove.Init( OnChangeBolsa, 1);
    }


    public bool EndInit()
    {
        if (MyGameplayManager.TwoPlayers)
            if (playerCheck == false) 
                playerCheck = true; 
            else
                return true;
        else
            return true;
        return false;
    }

    private void isChangeEnd()
    {
        Debug.Log("isChangeEnd");
        if (EndInit())
            OnEndIntro?.Invoke();
    }
}
