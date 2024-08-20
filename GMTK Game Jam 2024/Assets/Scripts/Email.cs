using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Email : App
{
    [SerializeField] GameObject emailPrefab;
    [SerializeField] Transform emailViewport;
    [SerializeField] TextMeshProUGUI sender, shortc, details; 

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

    public void SetEmailDetails(string sender, string content, int details)
    {
        //Instantiate Emails into the scroll view
        this.sender.text = sender;
        shortc.text = content;
        this.details.text = details.ToString();
    }
}