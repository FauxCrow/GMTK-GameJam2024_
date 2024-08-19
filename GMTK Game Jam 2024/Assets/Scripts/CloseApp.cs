using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TapGesture), typeof(PressGesture), typeof(ReleaseGesture))]
public class CloseApp : MonoBehaviour
{
    [SerializeField] App app;
    [SerializeField] Sprite[] states;

    int currSprite = 0;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void Close()
    {
        Debug.Log("Close App");
        app.CloseApp();
    }

    public void SwapSprite()
    {
        if (currSprite == 0)
        {
            currSprite = 1;
            image.sprite = states[currSprite];
        }
        else if (currSprite == 1)
        {
            currSprite = 0;
            image.sprite = states[currSprite];
        }
    }
}