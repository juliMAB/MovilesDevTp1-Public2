using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BolsaTrol : MonoBehaviour
{
    private Vector3 minPos;
    private Vector3 maxPos;

    void Start()
    {
        minPos = transform.position- Vector3.forward*2;
        maxPos = transform.position+ Vector3.forward*2;
        StartCoroutine(goTo(minPos));
    }

    IEnumerator goTo(Vector3 place)
    {
        float lTime=0;
        Vector3 pos = transform.position;
        while (lTime<1)
        {
            transform.position = Vector3.Lerp(pos, place, lTime);
            lTime += Time.deltaTime;
            yield return null;
        }
        transform.position = place;
        if (place == minPos)
            StartCoroutine(goTo(maxPos));
        else
            StartCoroutine(goTo(minPos));
    }
}
