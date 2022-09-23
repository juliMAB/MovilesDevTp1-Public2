using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviourSingleton<ObstaclesPool>
{
    public List<GameObject> cajitas = new List<GameObject>();
    public List<GameObject> taxis = new List<GameObject>();
    public List<GameObject> bolsas = new List<GameObject>();
}
