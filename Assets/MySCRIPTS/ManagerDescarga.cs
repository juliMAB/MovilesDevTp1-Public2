using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDescarga : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animator instructivo;
    [SerializeField] Canvas canvas;
    [SerializeField] BolsaMoveAnim animatorMoveAnim;
    [SerializeField] private Camera camera;
    DepositChangedCommand depositChange = new DepositChangedCommand();
    [SerializeField] private Mediator mediator;

    [SerializeField] private int bolsas;

    private Action OnEndDeposit;

    private void Start()
    {
        OnEndDeposit += EndDeposit;

        mediator.Subscribe<DepositChangedCommand>(InitDeposit);
        
        animatorMoveAnim.Init(ref OnEndDeposit,bolsas);
    }

    private void InitDeposit(DepositChangedCommand c)
    {
        if (!c.OnDeposit)
            return;
        camera.gameObject.SetActive(true);
        animator.enabled = true;
        animator.Play("StartDeposit");
        animatorMoveAnim.MyStart(c.BagsCuantity);
        canvas.gameObject.SetActive(true);
    }
    private void EndDeposit()
    {
        instructivo.Play("InstructivoDone");
        animator.Play("EndDeposit");
        animatorMoveAnim.Restart();
        Invoke("LasCallEndDeposit", 1);
    }
    private void LasCallEndDeposit()
    {
        camera.gameObject.SetActive(false);
        animator.enabled = false;
        depositChange.OnDeposit = false;
        mediator.Publish(depositChange);
        canvas.gameObject.SetActive(false);

    }
}
