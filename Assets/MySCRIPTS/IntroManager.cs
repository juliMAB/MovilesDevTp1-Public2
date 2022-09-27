using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] BolsaMoveAnim bolsaMove = null;

    [SerializeField] Animator introInstructivoAnim = null;
    [SerializeField] Animator introInstructivoAnimAndroid = null;

    [SerializeField] static bool playerCheck = false;

    [SerializeField] Action OnEndIntro = null;

    [SerializeField] Action OnChangeBolsa = null;

    [SerializeField] bool firstInstructivo = true;

    [SerializeField] FixedJoystick joystick = null;

    [SerializeField] InputLocal input = null;


    public void Init(Action OnEndIntro)
    {
        this.OnEndIntro = OnEndIntro;
        OnChangeBolsa += isChangeEnd; 
        bolsaMove.Init( OnChangeBolsa);

#if UNITY_ANDROID
        if (introInstructivoAnimAndroid!=null)
        {
            introInstructivoAnimAndroid.Play("InstrucvitoInit");
            Destroy (introInstructivoAnim.gameObject);
        }
#endif
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (introInstructivoAnim != null)
        {
            introInstructivoAnim.Play("InstrucvitoInit");
            Destroy(introInstructivoAnimAndroid.gameObject);
            Destroy(joystick.gameObject);
        }
#endif
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
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (introInstructivoAnim != null)
            introInstructivoAnim.Play("InstructivoDone");
#endif
#if UNITY_ANDROID
        if (introInstructivoAnimAndroid!=null)
            introInstructivoAnimAndroid.Play("InstructivoDone");
#endif
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
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        if (input.getvertical()>0)
        {
            if (introInstructivoAnim!=null)
            {
                firstInstructivo = false;
                introInstructivoAnim.Play("InstructivoIddle");
                bolsaMove.MyStart(1);
            }
        }
#endif
#if UNITY_ANDROID
        if (joystick.Vertical >= 0.8f)
        {
            if (introInstructivoAnimAndroid!=null)
            {
                firstInstructivo = false;
                introInstructivoAnimAndroid.Play("InstructivoIddle");
                bolsaMove.MyStart(1);
            }
        }
#endif

    }
}
