using System.Collections;
using UnityEngine;

public class Obstacle2 : MonoBehaviour
{
    #region EXPOSED_FIELD
    [SerializeField] LayerMask layerMaskPlayer;
    [SerializeField] bool inUse = false;
    #endregion

    #region PRIVATE_FIELD
    private Rigidbody _rb = null;
    private Collider _collider = null;
    #endregion

    #region UNITY_CALLS
    private void OnValidate()
    {
        if (_rb==null)
            _rb.GetComponent<Rigidbody>();
        if (_collider==null)
            _collider = GetComponent<Collider>();
    }
    void OnCollisionEnter(Collision coll)
    {
        
        if (inUse)
            return;
        if (((1 << coll.gameObject.layer) & layerMaskPlayer) != 0)
        {
            _rb.useGravity = true;
            coll.rigidbody.velocity = Vector3.zero;
            inUse = true;
            StartCoroutine(DestroyAfter(2));
        }
    }
    #endregion

    #region PRIVATE_IENUMERATOR
    IEnumerator DestroyAfter(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    #endregion

}
