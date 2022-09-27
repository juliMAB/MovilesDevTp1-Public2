using UnityEngine;

public class capture : MonoBehaviour
{
    public string folder = "ScreenShotFolder";
    private string localName;
    private void Start()
    {
        System.IO.Directory.CreateDirectory(folder);
        localName = string.Format("{0}/{1:D03} shot.png", folder, Time.frameCount); 
    }
    
    // Update is called once per frame
    public void takeShoot()
    {
        ScreenCapture.CaptureScreenshot(localName);
    }


}
