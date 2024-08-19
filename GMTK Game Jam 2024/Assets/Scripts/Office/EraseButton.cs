using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseButton : MonoBehaviour
{
    public Signature signature;
    
    void OnMouseDown()
    {
        signature.ResetColor();
    }
}
