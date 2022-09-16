using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneFade : MonoBehaviour
{
    public void ChangeToGame()
    {
        FadeController.Instance.FadeOut(1, Color.black, () => GameManager.Get().LoadGame());
    }
}
