using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
    public string imgbytes;
    IEnumerator RecordFrame()
    {
        yield return new WaitForEndOfFrame();
        var texture = ScreenCapture.CaptureScreenshotAsTexture();
        // do something with texture
        byte[] bytes = texture.EncodeToPNG();
        imgbytes = System.Convert.ToBase64String(bytes);
        // cleanup
        Object.Destroy(texture);
    }

    public void screenshot()
    {
        StartCoroutine(RecordFrame());
    }
}
