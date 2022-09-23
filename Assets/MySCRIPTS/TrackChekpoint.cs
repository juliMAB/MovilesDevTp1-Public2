using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChekpoint : MonoBehaviour
{
    #region EXPOSED_FIELD
    [SerializeField] TrackChekpoint Next;
    [SerializeField] Material localMaterial;
    #endregion

    #region UNITY_CALLS
    private void OnTriggerEnter(Collider other)
    {
        Taxi2 taxi = other.GetComponent<Taxi2>();
        if (taxi!=null)
        {
            taxi.SetDestination(Next.transform.position);
        }
    }
    #if !UNITY_EDITOR
    private void Start()
    {
        localMaterial.color = Color.clear;
    }
    #endif

    #endregion


}
