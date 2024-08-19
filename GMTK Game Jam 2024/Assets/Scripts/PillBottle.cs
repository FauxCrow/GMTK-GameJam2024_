using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottle : MonoBehaviour
{
    public GameObject arm;
    public float animationDuration;

    Vector3 armOriginalPosition;

    void Start()
    {
        

        armOriginalPosition = arm.transform.position;
    }

    void OnMouseDown()
    {
        Debug.Log("Pill Bottle clicked on");
        ArmMove();
    }

    void ArmMove()
    {
        Sequence armSequence = DOTween.Sequence();
        armSequence.Append(arm.transform.DOMove(transform.position, animationDuration / 2));
        armSequence.Append(arm.transform.DOMove(armOriginalPosition, animationDuration / 2));
        armSequence.Insert(animationDuration / 2, transform.DOMove(armOriginalPosition, animationDuration / 2));
    }
}