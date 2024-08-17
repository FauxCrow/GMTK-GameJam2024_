using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

public class Stamp : MonoBehaviour
{
    TransformGesture gesture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        transform.DOScale(1.2f, .1f);
    }

    private void OnMouseUp()
    {
        transform.DOScale(1f, .2f);
    }
}