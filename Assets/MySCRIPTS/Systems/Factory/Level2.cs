using UnityEngine;

public class Level2 : FactoryLevel
{
    private void Start()
    {
        Init();
    }
    public override void SpawnAll()
    {
        SpawnBolsas();

        SpawnCaja();

        SpawnCono();

        SpawnTaxis();
    }

    protected override void SpawnBolsas()
    {
        for (int i = 0; i < obstaclesPool.bolsasSpawnPoint.Count; i++)
        {
            if (!RandomSpawn(100))
                continue;
            Vector3 pos = obstaclesPool.bolsasSpawnPoint[i].transform.position;
            Quaternion rot = obstaclesPool.bolsasSpawnPoint[i].transform.rotation;
            Vector3 scl = obstaclesPool.bolsasSpawnPoint[i].transform.localScale;
            GameObject b = Instantiate(obstaclesPool.bolsa, pos, rot, obstaclesPool.bolsasParent.transform);
            obstaclesPool.bolsas.Add(b.GetComponent<Bolsa2>());
            b.AddComponent<BolsaTrol>();
            b.transform.localScale = scl;
        }
    }

    protected override void SpawnCaja()
    {
        for (int i = 0; i < obstaclesPool.cajitasSpawnPoint.Count; i++)
        {
            if (!RandomSpawn(50))
                continue;
            Vector3 pos = obstaclesPool.cajitasSpawnPoint[i].transform.position;
            Quaternion rot = obstaclesPool.cajitasSpawnPoint[i].transform.rotation;
            Vector3 scl = obstaclesPool.cajitasSpawnPoint[i].transform.localScale;
            GameObject b = Instantiate(obstaclesPool.caja2, pos, rot, obstaclesPool.CajasParent.transform);
            b.transform.localScale = scl;
        }
    }

    protected override void SpawnCono()
    {
        for (int i = 0; i < obstaclesPool.conosSpawnPoint.Count; i++)
        {
            if (!RandomSpawn(90))
                continue;
            Vector3 pos = obstaclesPool.conosSpawnPoint[i].transform.position;
            Quaternion rot = obstaclesPool.conosSpawnPoint[i].transform.rotation;
            Vector3 scl = obstaclesPool.conosSpawnPoint[i].transform.localScale;
            GameObject b = Instantiate(obstaclesPool.caja2, pos, rot, obstaclesPool.CajasParent.transform);
            b.transform.localScale = scl;
        }
    }

    protected override void SpawnTaxis()
    {
        for (int i = 0; i < obstaclesPool.taxisSpawnPoint.Count; i++)
        {
            if (!RandomSpawn(20))
                continue;
            Vector3 pos = obstaclesPool.taxisSpawnPoint[i].transform.position;
            Quaternion rot = obstaclesPool.taxisSpawnPoint[i].transform.rotation;
            Vector3 scl = obstaclesPool.taxisSpawnPoint[i].transform.localScale;
            GameObject b = Instantiate(obstaclesPool.taxi, pos, rot, obstaclesPool.taxisParent.transform);
            b.transform.localScale = scl;
        }
    }
}
