using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa2 : MonoBehaviour, Ipickapeable
{

	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private MeshRenderer visual;
	[SerializeField] private Collider collider;
	[SerializeField] private float valuE;
	[SerializeField] static private float value;

	private void OnValidate()
	{
		value = valuE;
	}
	static public float GetValue()
	{
		return value;
	}

	private void Start()
    {
		var main = particleSystem.main;
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	private void OnParticleSystemStopped()
	{
		gameObject.SetActive(false);
	}

	float Ipickapeable.Catch()
	{
        particleSystem.Play();
        visual.enabled = false;
        collider.enabled = false;
		return 1;
    }
}
