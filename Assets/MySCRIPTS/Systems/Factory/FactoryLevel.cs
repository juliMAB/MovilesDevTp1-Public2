using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryLevel : MonoBehaviour
{
    protected List<GameObject> cajitas = new List<GameObject>();
    protected List<GameObject> taxis = new List<GameObject>();
    protected List<GameObject> bolsas = new List<GameObject>();
   ObstaclesPool obstaclesPool= null;

    public void Start()
    {
        obstaclesPool = ObstaclesPool.Get();
        cajitas = obstaclesPool.cajitas;
        taxis = obstaclesPool.taxis;
        bolsas = obstaclesPool.bolsas;
    }

    public abstract void SpawnAll();
}
