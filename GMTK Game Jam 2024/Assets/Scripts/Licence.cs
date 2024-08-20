using UnityEngine;
using DG.Tweening;
using TMPro;
using System;

public class Licence : App
{
    [SerializeField] TextMeshProUGUI productNameText;
    [SerializeField] TextMeshProUGUI companyNameText;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] TextMeshProUGUI profitText;
    [SerializeField] TextMeshProUGUI tcText;

    public LicenseData[] licenseDatas;

    public override void OpenApp()
    {
        notificationIcon.SetActive(false);
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


    public override void NotificationAlert()
    {
        notificationIcon.SetActive(true);
    }

    public void SetLicense(LicenseData data){
        licenseDatas[data.number] = data;
    }

    public void SetPage(int page){
        Debug.Log(page);

        productNameText.text = "Product Name: " + "\n" + licenseDatas[page].productName;
        companyNameText.text = "Company Name: " + "\n" + licenseDatas[page].companyName;
        costText.text = "Production Cost: " + licenseDatas[page].prodCosts.ToString();
        profitText.text = "Profit: " + licenseDatas[page].profit.ToString();
        tcText.text = licenseDatas[page].termsConditions;
    }
}

[Serializable]
public class LicenseData{
    public string companyName, productName, termsConditions;
    public int prodCosts, profit, morality, rep, number;
}