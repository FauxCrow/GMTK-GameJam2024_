using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    [SerializeField] SpriteRenderer leftArm, rightArm;
    [SerializeField] Sprite[] leftSwaps;
    [SerializeField] Sprite[] rightSwaps;

    void SwapLeftArm(int index){
        leftArm.sprite = leftSwaps[index];
    }

    void SwapRightArm(int index){
        rightArm.sprite = rightSwaps[index];
    }
    
    public void Change(){
        //Use this function through data manager
    }
}
