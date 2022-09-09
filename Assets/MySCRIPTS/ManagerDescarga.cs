using System;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDescarga : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] Animator instructivo;
    [SerializeField] BolsaMoveAnim animatorMoveAnim;
    [SerializeField] private Mediator mediator;

    [SerializeField] private int bolsas;



    private SceneChangedCommand sceneChangedCommand = new SceneChangedCommand();
    private int bagCuantity;
    private Action OnEndDeposit;

    private void Start()
    {
        OnEndDeposit += EndDeposit;

       mediator.Subscribe<SceneChangedCommand>(InitDeposit);

        mediator.Subscribe<ScoreChangedCommand>(UpdateBagCuantityOnDeposit);
        
        animatorMoveAnim.Init( OnEndDeposit);
    }

    private void UpdateBagCuantityOnDeposit(ScoreChangedCommand c)
    {
        bagCuantity = c.BagsOnTruck;
    }
    private void InitDeposit(SceneChangedCommand c)
    {
        if (!(c.OnGoIndex==(int)GameState.Deposit))
           return;
       sceneChangedCommand.pjIndex = c.pjIndex;
       animator.enabled = true;
       animator.Play("StartDeposit");
       animatorMoveAnim.MyStart(bagCuantity);
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
        animator.enabled = false;
        sceneChangedCommand.OnGoIndex = (int)GameState.Game;
        mediator.Publish(sceneChangedCommand);
    }
}
