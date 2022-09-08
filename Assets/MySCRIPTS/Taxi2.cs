using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi2 : MonoBehaviour
{
    #region EXPOSED_FIELD
    [SerializeField] Transform firstNode;

    [SerializeField] float speed;
    
    [SerializeField] private Rigidbody _rb;
    #endregion

    #region PRIVATE_FIELDS
    private Vector3 DestinationPoint;
    #endregion

    #region UNITY_CALLS

    private void Start()
    {
        DestinationPoint = firstNode.position;
        transform.LookAt(DestinationPoint, Vector3.up);
    }

    private void OnEnable()
    {        
        if (_rb == null)
            _rb.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
    }

    #endregion

    #region PUBLIC_METHODS
    public void SetDestination(Vector3 newDestination)
    {
        DestinationPoint = newDestination;
        transform.LookAt(DestinationPoint, Vector3.up);
    }
    #endregion
}
