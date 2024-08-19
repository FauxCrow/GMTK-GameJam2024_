using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Clinic : App
{


    public override void OpenApp()
    {
        if(window.activeInHierarchy){
            CloseApp();
            return;
        }        
        
        window.SetActive(true);
        window.transform.localScale = new Vector3(0,0,0);
        window.transform.DOScale(new Vector3(1,1,1), animationDuration);
    }

    public override void CloseApp()
    {
        window.transform.localScale = new Vector3(1,1,1);
        window.transform.DOScale(new Vector3(0,0,0), animationDuration).OnComplete(() => {
            window.SetActive(false);
        });
    }

    public void PurchaseBottle(){
        //Insert functions
        //Deduct Money
        //Reset bottle on screen
        //Set Delivery if needed
    }
}