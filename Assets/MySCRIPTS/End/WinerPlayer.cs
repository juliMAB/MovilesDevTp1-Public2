using TMPro;
using UnityEngine;

public class WinerPlayer : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI tex;
    void Start()
    {
        tex.text = "Winner: ";
        if (GameManager.Get().score1 > GameManager.Get().score2)
        {
            tex.text += "Player1";
        }
        else if (GameManager.Get().score1 < GameManager.Get().score2)
        {
            tex.text += "Player2";
        }
        else
        {
            tex.text = "TIE";
        }
    }
}
