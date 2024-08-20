using UnityEngine;

public class LicenseReader : MonoBehaviour
{
    public Licence app;
    public TextAsset licensesJson;
    public Licenses licenses;
    public LawsuitReader lawsuit;
    public EmailReader email;

    int lowerLimit;
    int upperLimit;
    int randomChance;
    int emailLicense;
 
    void Start()
    {
        licenses = JsonUtility.FromJson<Licenses>(licensesJson.text);
    }

    // function generate 3 licenses for each day
    public void NewLicenses(int currentDay){
        switch (currentDay){
            case <5:
                lowerLimit = 0;
                upperLimit = 15;
                randomChance = 6;   // 16% chance
                break;
            case <10:
                lowerLimit = 0;
                upperLimit = 30;
                randomChance = 5;   // 20% chance
                break;
            case <15:
                lowerLimit = 0;
                upperLimit = 45;
                randomChance = 4;   // 25% chance
                break;
            case <20:
                lowerLimit = 15;
                upperLimit = 60;
                randomChance = 3;   // 33% chance
                break;
            case >20:
                lowerLimit = 30;
                upperLimit = licenses.licenses.Length;
                randomChance = 2;   // 50% chance
                break;
        }

        int chosenLicense = EmailCheck();

        // Generate license 3 times, using i as the license number out of 3
        for (int i = 1; i < 4; i++){
            int randomLicense = GenerateLicense(lowerLimit, upperLimit, i);

            if (i == chosenLicense){
                email.GenerateEmail(randomLicense);
                emailLicense = randomLicense;
            }
        }
    }

    public int IncentiveCheck(int choice){
        if (choice == emailLicense){
            return email.returnProfit();
        }
        else{
            return 0;
        }
    }

    // function: generate a lawsuit on a random chance after risky choices
    public void LawsuitCheck(){
        if (RandomInt(0, randomChance) == 0){
            lawsuit.GenerateLawsuit();
        }
    }

    // function: generate an email for a random license on a random chance
    public int EmailCheck(){
        if (RandomInt(0, randomChance) == 0){
            return RandomInt(1,4);
        }
        
        return -1;  // unreachable number
    }

    // function : call for a random selection of license data
    // lower/upper limit: allows for balancing of license intensity as game goes on -- can choose lower numbers for day 1, etc.
    // max level -- licenses.licenses.Length
    int GenerateLicense(int lowerLimit, int upperLimit, int licenseNo){
        // working with the assumption that license data gets more risky the higher the array number
        int randomLicense = RandomInt(lowerLimit, upperLimit);
        // int riskScale = Mathf.RoundToInt(randomLicense/10);     // one-tenths of license id as risk scale

        string companyName = licenses.licenses[randomLicense].company;
        string productName = licenses.licenses[randomLicense].product;
        string termsConditions = licenses.licenses[randomLicense].conditions;
        int productionCosts = licenses.licenses[randomLicense].costs;
        int profit = licenses.licenses[randomLicense].profit;
        int morality = licenses.licenses[randomLicense].morality;
        int reputation = licenses.licenses[randomLicense].reputation;

        // use above data to put in your license, depending on license no (1-3)

        LicenseData data = new()
        {
            companyName = companyName,
            productName = productName,
            termsConditions = termsConditions,
            prodCosts = productionCosts,
            profit = profit,
            morality = morality,
            rep = reputation,
            number = licenseNo
        };

        Debug.Log($"{data}, {app}");

        app.SetLicense(data);

        return randomLicense;
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
    public int morality;
    public int reputation;
}