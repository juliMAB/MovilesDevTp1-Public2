using System;
using UnityEngine;

public class ManagerDescarga : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] Animator instructivo;
    [SerializeField] Animator instructivoAndroid;
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
#if UNITY_ANDROID
        Destroy (instructivo.gameObject);
#endif
#if UNITY_STANDALONE
        Destroy (instructivoAndroid.gameObject);
#endif
    }

    private void UpdateBagCuantityOnDeposit(ScoreChangedCommand c)
    {
        bagCuantity = c.BagsOnTruck;
    }
    private void InitDeposit(SceneChangedCommand c)
    {
        if (!(c.OnGoIndex==(int)GameStage.Deposit))
           return;
       sceneChangedCommand.pjIndex = c.pjIndex;
       animator.enabled = true;
       animator.Play("StartDeposit");
       animatorMoveAnim.MyStart(bagCuantity);
   }
    private void EndDeposit()
    {
        if (instructivoAndroid!=null)
            instructivoAndroid.Play("InstructivoDone");
        else
            instructivo.Play("InstructivoDone");
        animator.Play("EndDeposit");
        animatorMoveAnim.Restart();
        Invoke("LasCallEndDeposit", 1);
    }
    private void LasCallEndDeposit()
    {
        animator.enabled = false;
        sceneChangedCommand.OnGoIndex = (int)GameStage.Game;
        mediator.Publish(sceneChangedCommand);
    }
}
