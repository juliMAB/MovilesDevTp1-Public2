using UnityEngine;

public class Level1 : FactoryLevel
{
    public override void SpawnAll()
    {
        for (int i = 0; i < cajitas.Count; i++)
        {
            int prc = Random.Range(0, 100);
            if (prc>75)
                cajitas[i].SetActive(false);
            else
                cajitas[i].SetActive(true);
        }
        for (int i = 0; i < bolsas.Count; i++)
            bolsas[i].SetActive(true);
        for (int i = 0; i < taxis.Count; i++)
            taxis[i].SetActive(false);
    }
}
