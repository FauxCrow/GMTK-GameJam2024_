using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arms : MonoBehaviour
{
    [SerializeField] SpriteRenderer leftArm, rightArm;
    [SerializeField] Sprite[] leftSwaps;
    [SerializeField] Sprite[] rightSwaps;
    [SerializeField] float grabAnimDuration;

    Vector2 leftArmOgPosition;

    void Start(){
        leftArmOgPosition = leftArm.transform.position;
    }

    void SwapLeftArm(int index){
        leftArm.sprite = leftSwaps[index];
    }

    void SwapRightArm(int index){
        rightArm.sprite = rightSwaps[index];
    }
    
    public void Change(){
        //Use this function through data manager
    }

    public void GrabPillBottle(GameObject bottlePos)
    {
        Debug.Log(bottlePos);
        Sequence armSequence = DOTween.Sequence();
        armSequence.Append(leftArm.transform.DOMove(bottlePos.transform.position, grabAnimDuration / 2));
        armSequence.Append(leftArm.transform.DOMove(leftArmOgPosition, grabAnimDuration / 2));
        armSequence.Insert(grabAnimDuration / 2, bottlePos.transform.DOMove(leftArmOgPosition, grabAnimDuration / 2)).OnComplete(() => {
            Destroy(bottlePos);
        });
    }
}
