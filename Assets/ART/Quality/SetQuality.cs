using TMPro;
using UnityEngine;

public class SetQuality : MonoBehaviour
{
    public void SetQuialityLevelDropdown(int index)
    {
        QualitySettings.SetQualityLevel(index, false);
    }
}
