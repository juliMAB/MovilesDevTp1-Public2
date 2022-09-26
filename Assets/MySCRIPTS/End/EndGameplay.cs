using System.Collections;
using UnityEngine;

public class EndGameplay : MonoBehaviour
{
    [SerializeField] Animator localAnimation1;
    [SerializeField] Animator localAnimation2;
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject canvas2;

    private FadeController m_fadeController;

    [SerializeField] float timeToBackMenu;

    private void Start()
    {
        FadeStart();
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        if (GameManager.Get().two_players)
        {
            canvas2.SetActive(true);
        }
        else
        {
            canvas1.SetActive(true);
        }
        StartCoroutine(OnStart(timeToBackMenu));
    }

    IEnumerator OnStart(float time)
    {
        yield return new WaitForSeconds(time);
        m_fadeController.FadeOut(1.0f, Color.black, () => { GameManager.Get().LoadMenu(); });
    }

    private void FadeStart()
    {

        m_fadeController = FadeController.Instance;
        m_fadeController.SetSortingOrder(1);
        m_fadeController.FadeIn(1.0f, Color.black);

        FadeController.Instance.FadeIn(1.0f);

    }
}
