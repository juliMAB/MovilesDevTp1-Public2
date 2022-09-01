using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChekpoint : MonoBehaviour
{
    [SerializeField] TrackChekpoint Next;

    private void OnTriggerEnter(Collider other)
    {
        Taxi2 taxi = other.GetComponent<Taxi2>();
        if (taxi!=null)
        {
            taxi.SetDestination(Next.transform.position);
        }
    }
}
