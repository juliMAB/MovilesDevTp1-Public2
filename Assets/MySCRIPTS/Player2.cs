using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float score;
    ScoreChangedCommand scoreChange = new ScoreChangedCommand();
    [SerializeField] private Mediator mediator;

    [SerializeField] private Vector3 respawnPoint;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        respawnPoint = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        Ipickapeable ipickapeable = other.GetComponent<Ipickapeable>();
        if (ipickapeable!=null)
        {
            score = ipickapeable.Catch();
            scoreChange.ScoreOnTruck = score;
            mediator.Publish(scoreChange);
            return;
        }
        Irespawneable irespawneable = other.GetComponent<Irespawneable>();
        if (irespawneable!=null)
        {
            respawnPoint = irespawneable.GetRespawnPoint();
        }
    }


    private void Respawn()
    {
        transform.position = respawnPoint;
        transform.rotation = Quaternion.identity;
        rb.velocity        = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if (transform.position.y<-10)
        {
            Respawn();
        }
    }
}
