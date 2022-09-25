using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle2 : MonoBehaviour
{
    #region EXPOSED_FIELD
    [SerializeField] private LayerMask layerMaskPlayer;
    [SerializeField] private bool inUse = false;
    [SerializeField] private Rigidbody _rb = null;
    [SerializeField] private Collider _collider = null;
    public UnityEvent OnDestroyThis = null;
    #endregion

    #region PRIVATE_FIELD
    #endregion

    #region UNITY_CALLS

    private void Start()
    {
        if (_rb == null)
            _rb.GetComponent<Rigidbody>();
        if (_collider == null)
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
            coll.rigidbody.angularVelocity = Vector3.zero;
            inUse = true;
            if (OnDestroyThis != null)
                OnDestroyThis.Invoke();
            else
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
