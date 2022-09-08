using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolsa2 : MonoBehaviour, Ipickapeable
{
    #region EXPOSED_FIELD
    [SerializeField] private ParticleSystem particleSystem;
	[SerializeField] private MeshRenderer visual;
	[SerializeField] private Collider collider;
    #endregion

    #region UNITY_CALLS
    private void Start()
    {
		var main = particleSystem.main;
		main.stopAction = ParticleSystemStopAction.Callback;
	}
	private void OnParticleSystemStopped()
	{
		gameObject.SetActive(false);
	}
    #endregion

    #region INTERFACE_METHODS
    int Ipickapeable.Catch()
	{
		StartDie();
        return 1;
    }
    #endregion

    #region PRIVATE_METHODS
    private void StartDie()
	{
        particleSystem.Play();
        visual.enabled = false;
        collider.enabled = false;
	}
    #endregion
}
