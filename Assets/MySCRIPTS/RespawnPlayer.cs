using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    #region PRIVATE_FIELDS
    private Vector3 respawnPoint;
    private Rigidbody rb;
    #endregion

    #region UNITY_CALLS

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -10)
        {
            Respawn();
        }
        if (Vector3.Angle(transform.up, Vector3.up) > 80)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Irespawneable irespawneable = other.GetComponent<Irespawneable>();
        if (irespawneable != null)
        {
            respawnPoint = irespawneable.GetRespawnPoint();
        }
    }
    #endregion

    #region PRIVATE_METHODS
    private void Respawn()
    {
        transform.position = respawnPoint;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    #endregion
}
