using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChekpoint : MonoBehaviour
{
    #region EXPOSED_FIELD
    [SerializeField] TrackChekpoint Next;
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
    #endregion
}
