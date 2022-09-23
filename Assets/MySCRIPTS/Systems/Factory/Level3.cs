using UnityEngine;

public class Level3 : FactoryLevel
{
    public override void SpawnAll()
    {
        for (int i = 0; i < cajitas.Count; i++)
            cajitas[i].SetActive(true);
        for (int i = 0; i < bolsas.Count; i++)
            bolsas[i].SetActive(true);
        for (int i = 0; i < taxis.Count; i++)
                taxis[i].SetActive(false);
    }
}

