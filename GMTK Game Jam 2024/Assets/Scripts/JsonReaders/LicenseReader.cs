using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicenseReader : MonoBehaviour
{
    public TextAsset licensesJson;
    public Licenses licenses;
 
    void Start()
    {
        licenses = JsonUtility.FromJson<Licenses>(licensesJson.text);
    }

    // function generate 3 licenses for each day
    public void NewLicenses(){
        // not sure how you're doing the day system but i would say choose upper/lower limit based on day number then generate 3 using GenerateLicense() woo
    }

    // function : call for a random selection of license data
    // lower/upper limit: allows for balancing of license intensity as game goes on -- can choose lower numbers for day 1, etc.
    // max level -- licenses.licenses.Length
    void GenerateLicense(int lowerLimit, int upperLimit){
        // working with the assumption that license data gets more risky the higher the array number
        int randomLicense = RandomInt(lowerLimit, upperLimit);
        // int riskScale = Mathf.RoundToInt(randomLicense/10);     // one-tenths of license id as risk scale

        string companyName = licenses.licenses[randomLicense].company;
        string productName = licenses.licenses[randomLicense].product;
        string termsConditions = licenses.licenses[randomLicense].conditions;
        int productionCosts = licenses.licenses[randomLicense].costs;
        int profit = licenses.licenses[randomLicense].profit;

        // use above data to put in your license
    }

    int RandomInt(int lowerLimit, int upperLimit){
        return UnityEngine.Random.Range(lowerLimit, upperLimit);
    }
}

[System.Serializable]
public class Licenses
{
    public LicenseClass[] licenses;
}

[System.Serializable]
public struct LicenseClass
{
    public string company;
    public string product;
    public int costs;
    public int profit;
    public string conditions;
}