using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBottle : MonoBehaviour
{
    Arms arms;
    PillManager manager;

    public void SetPill(Arms arms, PillManager manager)
    {
        this.arms = arms;
        this.manager = manager;
    }

    void OnMouseDown(){
        arms.GrabPillBottle(gameObject);
    }
}