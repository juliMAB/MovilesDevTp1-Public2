using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float score;
    ScoreChangedCommand scoreChange = new ScoreChangedCommand();
    [SerializeField] private Mediator mediator;
    private void OnTriggerEnter(Collider other)
    {
        Ipickapeable ipickapeable = other.GetComponent<Ipickapeable>();
        if (ipickapeable!=null)
        {
            score = ipickapeable.Catch();
            scoreChange.ScoreOnTruck = score;
            mediator.Publish(scoreChange);
        }
    }
}
