using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;
    #endregion

    #region UNITY_CALLS
    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }
    #endregion

    #region PRIVATE_METHODS
    private void HandleTranslation()
    {
        var targetPasition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPasition, translateSpeed * Time.deltaTime);
    }

    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed);
    }
    #endregion
}
