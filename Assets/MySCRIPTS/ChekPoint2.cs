using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChekPoint2 : MonoBehaviour, Irespawneable
{

    public Vector3 GetRespawnPoint()
    {
        return gameObject.transform.position;
    }
}
