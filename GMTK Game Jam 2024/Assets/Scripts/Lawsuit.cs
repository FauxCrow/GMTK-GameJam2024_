using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Lawsuit : App
{
    [SerializeField] TextMeshProUGUI caseNumber;
    [SerializeField] TextMeshProUGUI details;
    [SerializeField] TextMeshProUGUI payoff, fightInCourt;

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

    public void SetLawsuit(LawsuitData data){
        caseNumber.text = "Case Number:" + Random.Range(0, 999).ToString("000");
        details.text = data.LawsuitDetails;
        payoff.text = "Payoff:" + "\n" + "$" + data.PayoffValue.ToString();
        fightInCourt.text = "Fight:" + "\n" + "$" + data.FightValue.ToString();
    }
}