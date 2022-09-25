using UnityEngine;

public class ForceEndGame : MonoBehaviour
{
    [SerializeField] private LayerMask layerMaskPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & layerMaskPlayer) != 0)
        {
            MyGameplayManager.Get().ForceToEnd();
        }
    }
}
