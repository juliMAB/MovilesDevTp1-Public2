using UnityEngine;

public class Level1 : FactoryLevel
{
    private void Start()
    {
        Init();
    }
    public override void SpawnAll()
    {
        SpawnBolsas();

        SpawnCaja();
    }

    protected override void SpawnBolsas()
    {
        for (int i = 0; i < obstaclesPool.bolsasSpawnPoint.Count; i++)
        {
            if (!RandomSpawn(100))
                return;
            Vector3 pos = obstaclesPool.bolsasSpawnPoint[i].transform.position;
            Quaternion rot = obstaclesPool.bolsasSpawnPoint[i].transform.rotation;
            Vector3 scl = obstaclesPool.bolsasSpawnPoint[i].transform.localScale;
            GameObject b = Instantiate(obstaclesPool.bolsa, pos, rot, obstaclesPool.bolsasParent.transform);
            b.transform.localScale = scl;
        }
    }

    protected override void SpawnCaja()
    {
        for (int i = 0; i < obstaclesPool.cajitasSpawnPoint.Count; i++)
        {
            if (!RandomSpawn(70))
                return;
            Vector3 pos = obstaclesPool.cajitasSpawnPoint[i].transform.position;
            Quaternion rot = obstaclesPool.cajitasSpawnPoint[i].transform.rotation;
            Vector3 scl = obstaclesPool.cajitasSpawnPoint[i].transform.localScale;
            GameObject b = Instantiate(obstaclesPool.caja2, pos, rot, obstaclesPool.CajasParent.transform);
            b.transform.localScale = scl;
        }
    }

    protected override void SpawnCono()
    {
        throw new System.NotImplementedException();
    }

    protected override void SpawnTaxis()
    {
        throw new System.NotImplementedException();
    }
}
