using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour
{
    [SerializeField] Sprite[] states;
    Image img;


    void Start(){
        img = GetComponent<Image>();
    }

    public void ButtonDown(){
        img.sprite = states[1];
    }

    public void ButtonUp(){
        img.sprite = states[0];
    }
}