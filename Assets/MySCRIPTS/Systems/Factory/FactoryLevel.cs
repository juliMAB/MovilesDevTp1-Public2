using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryLevel : MonoBehaviour
{
   protected ObstaclesPool obstaclesPool= null;

    public void Init()
    {
        obstaclesPool = ObstaclesPool.Get();
        SpawnAll();
    }

    public abstract void SpawnAll();

    protected abstract void SpawnBolsas();

    protected abstract void SpawnCaja();

    protected abstract void SpawnCono();

    protected abstract void SpawnTaxis();

    protected bool RandomSpawn(int percent)
    {
        int randomNum = Random.Range(0, 101);
        return percent >= randomNum;
    }
}
