using UnityEngine;

public class AreaDescarga : MonoBehaviour
{
    [SerializeField] private bool inUse = false;
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
}
