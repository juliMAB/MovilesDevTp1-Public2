
public interface Ipickapeable
{
    float Catch();
}

public interface Irespawneable
{
    UnityEngine.Vector3 GetRespawnPoint();
}

public interface Idownloadable 
{
    bool HasBags();

    void StopCar();

    void IntroDeposit();

}


