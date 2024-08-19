using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTexture : MonoBehaviour
{
    public Signature signature;
    
    void OnMouseDown()
    {
        signature.SaveText();
    }
}
