using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailReader : MonoBehaviour
{
    [SerializeField] Email app;
    public TextAsset emailsJson;
    public Emails emails;

    int emailProfit;

    void Start()
    {
        emails = JsonUtility.FromJson<Emails>(emailsJson.text);
    }

    public void GenerateEmail(int licenseNumber){
        string subjectLine = emails.emails[licenseNumber].subject;
        string content = emails.emails[licenseNumber].details;
        int profit = emails.emails[licenseNumber].incentive;

        // use above data to put in your email
        app.SetEmailDetails(subjectLine, content ,profit);

        emailProfit = profit;
    }

    public int returnProfit(){
        return emailProfit;
    }
}

[System.Serializable]
public class Emails
{
    public EmailClass[] emails;
}

[System.Serializable]
public struct EmailClass
{
    public string subject;
    public string details;
    public int incentive;
}
