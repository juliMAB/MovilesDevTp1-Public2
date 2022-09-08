using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa2 : MonoBehaviour, Ipickapeable
{

	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private MeshRenderer visual;
	[SerializeField] private Collider collider;

	private void Start()
    {
		var main = particleSystem.main;
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	private void OnParticleSystemStopped()
	{
		gameObject.SetActive(false);
	}

	int Ipickapeable.Catch()
	{
		StartDie();
        return 1;
    }
	private void StartDie()
	{
        particleSystem.Play();
        visual.enabled = false;
        collider.enabled = false;
	}
}
