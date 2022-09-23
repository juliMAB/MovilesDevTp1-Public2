using UnityEngine;

public class AreaDescarga : MonoBehaviour
{
    #region EXPOSED_FIELD
    [SerializeField] private bool inUse = false;
    [SerializeField] Material localMaterial;
    #endregion

    #region UNITY_CALLS

    private void OnTriggerEnter(Collider other)
    {
        if (inUse)
            return;
        Idownloadable idownloadable = other.gameObject.GetComponent<Idownloadable>();
        if (idownloadable != null)
        {
            if (!idownloadable.HasBags())
                return;
            inUse = true;
            other.gameObject.transform.position = transform.position;
            idownloadable.IntroDeposit();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Idownloadable idownloadable = other.gameObject.GetComponent<Idownloadable>();
        if (idownloadable != null)
            inUse = false;
    }
#if !UNITY_EDITOR
    private void Start()
    {
        localMaterial.color = Color.clear;
    }
#endif
    #endregion
}
