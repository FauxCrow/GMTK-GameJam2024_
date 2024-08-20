using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerMonitor : MonoBehaviour
{
    public Camera officeCamera, desktopCamera;
    public RenderTexture monitorTex;
    public Window window;

    void OnMouseDown()
    {
        desktopCamera.targetTexture = null;
        window.windowUpdate();      // updates window sprite when computer open only :)

    }

    //For some reason setting the targetTexture to null changes the camera
    // set the texture back to siwtch back to office scene
}