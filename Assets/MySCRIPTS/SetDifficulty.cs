using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    public void ChangeDifficulty(int v)
    {
        GameManager.Get().dificulty = v;
    }

    public void SetPlayers(bool v)
    {
        GameManager.Get().two_players = v;
    }
}
