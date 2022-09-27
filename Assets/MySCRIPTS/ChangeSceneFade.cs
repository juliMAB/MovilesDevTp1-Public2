using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneFade : MonoBehaviour
{
    private void Start()
    {
        FadeStart();
    }
    public void ChangeToGame()
    {
        FadeController.Instance.FadeOut(1, Color.black, () => GameManager.Get().LoadGame());
    }
    public void ChangeToMenu()
    {
        FadeController.Instance.FadeOut(1, Color.black, () => GameManager.Get().LoadMenu());
    }
    public void ChangeToQuit()
    {
        FadeController.Instance.FadeOut(1, Color.black, () => GameManager.Get().Quit());
    }
    private void FadeStart()
    {

        FadeController m_fadeController = FadeController.Instance;
        m_fadeController.SetSortingOrder(1);
        m_fadeController.FadeIn(1.0f, Color.black);

        FadeController.Instance.FadeIn(1.0f);

    }
}
