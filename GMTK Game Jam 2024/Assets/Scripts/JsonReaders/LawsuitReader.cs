using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawsuitReader : MonoBehaviour
{
    public TextAsset lawsuitJson;
    public Lawsuits lawsuits;
    [SerializeField] Lawsuit app;
 
    void Start()
    {
        lawsuits = JsonUtility.FromJson<Lawsuits>(lawsuitJson.text);
    }

    public void GenerateLawsuit(){
        int lawsuitNo = UnityEngine.Random.Range(0, 100);

        int fight = lawsuits.lawsuits[0].fight + UnityEngine.Random.Range(1, 10) * 200;
        int payOff = lawsuits.lawsuits[0].pay + UnityEngine.Random.Range(1, 10) * 1000;

        string lawsuitInfo = lawsuits.lawsuits[0].details + payOff;

        // use above data to put in your lawsuit
        app.SetLawsuit(lawsuitNo, lawsuitInfo, fight, payOff);
    }
}

[System.Serializable]
public class Lawsuits
{
    public LawsuitsClass[] lawsuits;
}

[System.Serializable]
public struct LawsuitsClass
{
    public int licenseNo;
    public string details;
    public int fight;
    public int pay;
}
