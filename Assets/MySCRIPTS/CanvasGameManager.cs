using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameManager : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Mediator mediator;

    [SerializeField] private TextMeshProUGUI bagsOnTruckTMP;
    [SerializeField] private TextMeshProUGUI totalMoneyTMP;
    [SerializeField] private Image ImagenTop;
    [SerializeField] private Sprite[] TopTruckSprite;

    [SerializeField] private float timeToChangeTopImageAnim;
    #endregion

    #region PRIVATE_FIELDS
    private Coroutine currentCorrutine;
    #endregion

    #region UNITY_CALLS
    private void Start()
    {
        mediator.Subscribe<ScoreChangedCommand>(ScoreChangeUI);
    }
    #endregion

    #region PRIVATE_METHODS
    private void ScoreChangeUI(ScoreChangedCommand c)
    {
        bagsOnTruckTMP.text = "Truck: " + c.BagsOnTruck.ToString();
        totalMoneyTMP.text = "Total: " + c.ScoreOnGlobal.ToString();

        switch (c.BagsOnTruck)
        {
            case 0: { ImagenTop.sprite = TopTruckSprite[0]; if (currentCorrutine != null) StopCoroutine(currentCorrutine); return; }
            case 1: { ImagenTop.sprite = TopTruckSprite[1]; return; }
            case 2: { ImagenTop.sprite = TopTruckSprite[2]; return; }
            case 3: { ImagenTop.sprite = TopTruckSprite[3]; currentCorrutine = StartCoroutine(ChangeSpriteGoDeposit()); return; }
            default:
                break;
        }
    }
    #endregion

    #region PRIVATE_CORRUTINE
    private IEnumerator ChangeSpriteGoDeposit()
    {
        int b=3;
        while (true)
        {
            yield return new WaitForSeconds(timeToChangeTopImageAnim);
            ImagenTop.sprite = TopTruckSprite[b++];
            if (b == 5)
                b = 3;
        }
    }
    #endregion
}
