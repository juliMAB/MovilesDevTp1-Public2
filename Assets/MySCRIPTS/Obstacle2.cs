using System.Collections;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    [SerializeField] LayerMask layerMaskPlayer;
    [SerializeField] bool inUse = false;

    [SerializeField] Rigidbody _rb = null;
    [SerializeField] BoxCollider _collider = null;
    void OnCollisionEnter(Collision coll)
    {
        
        if (inUse)
            return;
        if (((1 << coll.gameObject.layer) & layerMaskPlayer) != 0)
        {
            _rb.useGravity = true;
            coll.rigidbody.velocity = Vector3.zero;
            _collider.enabled = false;
            inUse = true;
            StartCoroutine(DestroyAfter(2));
        }
    }

    IEnumerator DestroyAfter(float time)
    {
        while (true)
        {

        }
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}
