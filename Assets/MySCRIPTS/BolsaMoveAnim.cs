using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class BolsaMoveAnim : MonoBehaviour
{
    [SerializeField] private GameObject[] bolsa;
    [SerializeField] private Transform[] pos;
    [SerializeField, Range(0, 4)] private int state;
    [SerializeField, Range(0, 1)] private float speedPerStage;
    [SerializeField] private float bonusTime;
    private Coroutine currentAnim = null;

    private Coroutine BonusAnim = null;

    [SerializeField] private int bolsasDisponibles = 3;

    [SerializeField] private int currentBag = 0;

    [SerializeField] private bool input = false;

    [SerializeField] Slider bonusProgress = null;

    [SerializeField] Mediator mediator = null;

    private Action OnEndDescarga; 

    private float horizontalValue;
    private float VerticalValue;

    private ScoreChangedCommand c = new ScoreChangedCommand();

    private float localscore;

    public void Init(ref Action OnEndDescarga, int bolsas)
    {
        this.OnEndDescarga = OnEndDescarga;
        this.OnEndDescarga += Restart;
        mediator.Subscribe<ScoreChangedCommand>(GetScoreOnMediator);

    }

    private void GetScoreOnMediator(ScoreChangedCommand c)
    {
        this.c = c;
    }
    public void MyStart(int bolsasCuantity)
    {
        bolsasDisponibles = bolsasCuantity;
        input = true;
    }

    public void Restart()
    {
        currentBag = 0;
        bolsasDisponibles = 0;
        input = false;
        bonusProgress.gameObject.SetActive(false);
        if (BonusAnim != null)
        {
            BonusAnim = null;
        }
    }
    private void Update()
    {
        if (!input)
            return;
        switch (state)
        {
            case 0:
                if (horizontalValue < 0)
                {
                    bolsa[currentBag].SetActive(true);
                    bolsa[currentBag].transform.position = pos[0].position;
                    if (currentAnim != null)
                        StopCoroutine(currentAnim);
                    currentAnim = StartCoroutine(AnimMove(pos[0].position, pos[1].position, bolsa[currentBag].transform));
                    state = 1;
                    if(bonusProgress!=null && !bonusProgress.gameObject.activeSelf)
                    {

                        bonusProgress.gameObject.SetActive(true);
                        bonusProgress.value = bonusProgress.minValue;
                    }
                    if (BonusAnim != null)
                    {
                        StopCoroutine(BonusAnim);
                        BonusAnim = null;
                    }
                        
                    if (BonusAnim == null)
                        BonusAnim = StartCoroutine(AnimMoveSlider(bonusTime));
                    
                }
                return;
            case 1:
                if (VerticalValue < 0)
                {
                    if (currentAnim != null)
                        StopCoroutine(currentAnim);
                    currentAnim = StartCoroutine(AnimMove(pos[1].position, pos[2].position, bolsa[currentBag].transform));
                    state = 2;
                }
                return;
            case 2:
                if (horizontalValue > 0)
                {
                    if (currentAnim != null)
                        StopCoroutine(currentAnim);
                    currentAnim = StartCoroutine(AnimMove(pos[2].position, pos[3].position, bolsa[currentBag].transform));
                    state = 3;
                }
                return;
            case 3:
                if (currentAnim==null)
                currentAnim = StartCoroutine(AnimMoveEnd(pos[3].position, pos[4].position, bolsa[currentBag].transform));
                return;
            case 4:
                currentBag++;
                if (bonusProgress != null && bonusProgress.enabled)
                {
                    c.ScoreOnGlobal += bonusProgress.value * Bolsa2.GetValue();
                    c.ScoreOnTruck = 0;
                    mediator.Publish(c);
                    if(BonusAnim!=null)
                        StopCoroutine(BonusAnim);
                    bonusProgress.gameObject.SetActive(false);
                }
                else
                {
                    c.ScoreOnGlobal = bonusProgress.value;
                }
                state = 0;
                if (currentBag == bolsasDisponibles)
                    OnEndDescarga?.Invoke();
                return;
        }
    }

    private void LateUpdate()
    {
        GetInput();
    }

    void GetInput()
    {
        if (!input)
            return;
        horizontalValue = Input.GetAxis("Horizontal");
        VerticalValue = Input.GetAxis("Vertical");
    }

    IEnumerator AnimMove(Vector3 origin, Vector3 destino, Transform bag)
    {
        float currentTime = 0;
        while (currentTime < speedPerStage)
        {
            currentTime += Time.deltaTime;
            bag.position = Vector3.Lerp(origin, destino, currentTime / speedPerStage);
            yield return null;
        }
        currentAnim = null;
    }
    IEnumerator AnimMoveEnd(Vector3 origin, Vector3 destino, Transform bag)
    {
        float currentTime = 0;
        while (currentTime < speedPerStage)
        {
            currentTime += Time.deltaTime;
            bag.position = Vector3.Lerp(origin, destino, currentTime / speedPerStage);
            yield return null;
        }
        bag.gameObject.SetActive(false);
        state = 4;
    }

    IEnumerator AnimMoveSlider(float time)
    {
        float totaltime = time;
        while (time>0)
        {
            time -= Time.deltaTime;
            bonusProgress.value = bonusProgress.maxValue - (bonusProgress.maxValue / totaltime * time);
            yield return null;
        }
        bonusProgress.value = 0;
        BonusAnim = null;
        bonusProgress.gameObject.SetActive(false);
    }
}
