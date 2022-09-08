using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasGameManager : MonoBehaviour
{
    [SerializeField] Mediator mediator;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI text2;
    [SerializeField] Image ImagenTop;
    [SerializeField] Sprite[] TopTruckSprite;

    [SerializeField] float timeToChangeTopImageAnim;

    private Coroutine currentCorrutine;

    private void Start()
    {
        mediator.Subscribe<ScoreChangedCommand>(ScoreChangeUI);
    }

    void ScoreChangeUI(ScoreChangedCommand c)
    {
        text.text = "Truck: " + c.BagsOnTruck.ToString();
        text2.text = "Total: " + c.ScoreOnGlobal.ToString();

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

    IEnumerator ChangeSpriteGoDeposit()
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
}
