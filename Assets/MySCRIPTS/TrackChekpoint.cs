using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackChekpoint : MonoBehaviour
{
    #region EXPOSED_FIELD
    [SerializeField] TrackChekpoint Next;
    [SerializeField] Material localMaterial;
    [SerializeField] LayerMask taxiLayer;
    [SerializeField] bool lastNode;
    #endregion

    #region UNITY_CALLS
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & taxiLayer) != 0)
        {
            Taxi2 taxi = other.GetComponent<Taxi2>();
            if (taxi != null)
            {
                if (lastNode)
                {

                    taxi.transform.position = Next.transform.position;
                    taxi.SetDestination(Next.Next.transform.position);
                }
                else
                taxi.SetDestination(Next.transform.position);

            }
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
