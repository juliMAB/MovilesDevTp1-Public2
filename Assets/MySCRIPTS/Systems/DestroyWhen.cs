using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhen : MonoBehaviour
{
    public void OnCall()
    {
        Destroy(gameObject);
    }
}
