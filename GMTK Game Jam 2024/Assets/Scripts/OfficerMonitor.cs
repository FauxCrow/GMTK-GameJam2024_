using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerMonitor : MonoBehaviour
{
    [SerializeField] GameManager gm;

    public Camera officeCamera, desktopCamera;
    public RenderTexture monitorTex;
    public Window window;

    void OnMouseDown()
    {
        if(!gm.GameInPlay) return;
        desktopCamera.targetTexture = null;
        window.WindowUpdate();      // updates window sprite when computer open only :)

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && gm.GameInPlay){
            desktopCamera.targetTexture = monitorTex;
        }
    }

    public void Reset(){
        desktopCamera.targetTexture = monitorTex;
    }

    //For some reason setting the targetTexture to null changes the camera
    // set the texture back to siwtch back to office scene
}