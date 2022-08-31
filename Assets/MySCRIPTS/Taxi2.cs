using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi2 : MonoBehaviour
{
    [SerializeField] Vector3 DestinationPoint;

    [SerializeField] Rigidbody _rb;

    [SerializeField] float speed;

    private void Start()
    {
        transform.LookAt(DestinationPoint, Vector3.up);
    }
    private void Update()
    {
        _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
    }
    public void SetDestination(Vector3 newDestination)
    {
        DestinationPoint = newDestination;
        transform.LookAt(DestinationPoint, Vector3.up);
    }



}
