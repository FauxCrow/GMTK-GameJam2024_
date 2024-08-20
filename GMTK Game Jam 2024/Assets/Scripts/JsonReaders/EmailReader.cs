using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailReader : MonoBehaviour
{
    public TextAsset emailsJson;
    public Emails emails;

    void Start()
    {
        emails = JsonUtility.FromJson<Emails>(emailsJson.text);
    }

    void GenerateEmail(int licenseNumber){
        string subjectLine = emails.emails[licenseNumber].subject;
        string content = emails.emails[licenseNumber].details;
        int profit = emails.emails[licenseNumber].incentive;

        // use above data to put in your email
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
