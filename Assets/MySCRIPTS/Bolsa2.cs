using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa2 : MonoBehaviour
{

	[SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private MeshRenderer visual;
	[SerializeField] private Collider collider;


	private void Start()
    {
		var main = particleSystem.main;
		main.stopAction = ParticleSystemStopAction.Callback;
	}


    public void Catch()
	{
		particleSystem.Play();
		visual.enabled = false;
		collider.enabled = false;
	}
	private void OnParticleSystemStopped()
	{
		gameObject.SetActive(false);
	}
}
