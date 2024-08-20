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

    [SerializeField] DataManager dataManager;

    int payOff;
    int fightCourt;
    bool canPay = false;

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

    public void SetLawsuit(int number, string info, int pay, int fight){
        caseNumber.text = "Case Number:" + number;
        details.text = info;
        payoff.text = "Payoff:" + "\n" + "$" + pay;
        fightInCourt.text = "Fight:" + "\n" + "$" + fight;

        payOff = pay;
        fightCourt = fight;
        canPay = true;
    }

    public void pay(){
        if (canPay){
            dataManager.PayLawsuit(payOff);
            canPay = false;
        }
    }

    public void fight(){
        if (canPay){
            dataManager.FightLawsuit(fightCourt);
            canPay = false;
        }
    }
}