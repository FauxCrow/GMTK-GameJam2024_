using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficerMonitor : MonoBehaviour
{
    public GameObject officeCamera, desktopCamera;

    void OnMouseDown()
    {
        officeCamera.SetActive(false);
        desktopCamera.SetActive(true);
    }
}