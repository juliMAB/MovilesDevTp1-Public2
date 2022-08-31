using UnityEngine;

public class AreaDescarga : MonoBehaviour
{
    [SerializeField] private bool inUse = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        Idownloadable idownloadable = other.gameObject.GetComponent<Idownloadable>();
        if (idownloadable != null && inUse == false)
        {
            if (!idownloadable.HasBags())
                return;
            inUse = true;
            idownloadable.StopCar();
            other.gameObject.transform.position = gameObject.transform.position;
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
