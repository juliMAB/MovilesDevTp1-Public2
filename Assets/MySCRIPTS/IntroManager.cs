using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] BolsaMoveAnim bolsaMove = null;

    [SerializeField] Animator introInstructivoAnim = null;

    [SerializeField] static bool playerCheck = false;

    [SerializeField] Action OnEndIntro = null;

    [SerializeField] Action OnChangeBolsa = null;

    [SerializeField] bool input = true;

    [SerializeField] bool firstInstructivo = true;

    public void Init( Action OnEndIntro)
    {
        this.OnEndIntro = OnEndIntro;
        OnChangeBolsa += isChangeEnd; 
        bolsaMove.Init( OnChangeBolsa);
        bolsaMove.MyStart(1);
        introInstructivoAnim.Play("InstrucvitoInit");
    }


    private bool EndInit()
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
        if (EndInit())
            OnEndIntro?.Invoke();
    }

    private void Update()
    {
        InputW();
    }

    private void InputW()
    {
        if (!firstInstructivo)
            return;
        if (Input.GetKey(KeyCode.W))
        {
            firstInstructivo = false;
            introInstructivoAnim.Play("InstructivoIddle");
        }
    }
}
