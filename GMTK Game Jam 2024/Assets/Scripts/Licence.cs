using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Licence : App
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
}