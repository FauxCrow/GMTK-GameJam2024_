using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Email : App
{
    [SerializeField] GameObject emailPrefab;
    [SerializeField] Transform emailViewport;

    public override void OpenApp()
    {
        if(window.activeInHierarchy){
            CloseApp();
            return;
        }    

        window.SetActive(true);
        window.transform.localScale = new Vector3(0,0,0);
        window.transform.DOScale(new Vector3(1,1,1), animationDuration);
        GenerateEmails();
    }

    public override void CloseApp()
    {
        window.transform.localScale = new Vector3(1,1,1);
        window.transform.DOScale(new Vector3(0,0,0), animationDuration).OnComplete(() => {
            window.SetActive(false);
        });
    }

    void GenerateEmails()
    {
        //Instantiate Emails into the scroll view
        //Get the number of emails from the datamanager
    }

    void SetEmailDate(EmailData data)
    {
        GameObject email = Instantiate(emailPrefab,emailViewport);
        EmailSingle em = email.GetComponent<EmailSingle>();
        em.SetEmail(data);
    }
}