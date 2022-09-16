using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioVolumen : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup group;

    [SerializeField] private string groupName;
    public void SetLevel(float sliderValue)
    {
        group.audioMixer.SetFloat(groupName, Mathf.Log10(sliderValue) * 20);
    }
}
