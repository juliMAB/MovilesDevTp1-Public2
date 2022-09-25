using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviourSingleton<ObstaclesPool>
{

    public List<GameObject> cajitasSpawnPoint = new List<GameObject>();
    public List<GameObject> conosSpawnPoint = new List<GameObject>();
    public List<GameObject> taxisSpawnPoint = new List<GameObject>();
    public List<GameObject> bolsasSpawnPoint = new List<GameObject>();

    public List<Bolsa2> bolsas = new List<Bolsa2>();

    public GameObject CajasParent;
    public GameObject taxisParent;
    public GameObject bolsasParent;

    public GameObject bolsa;
    public GameObject taxi;
    public GameObject caja1;
    public GameObject caja2;
    public GameObject cono;
}
