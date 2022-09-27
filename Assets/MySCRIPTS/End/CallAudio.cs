using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void OnEnable()
    {
        audioSource.Play();
        this.enabled = false;
    }
}
