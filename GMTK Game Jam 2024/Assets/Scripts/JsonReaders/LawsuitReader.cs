using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawsuitReader : MonoBehaviour
{

    public TextAsset lawsuitJson;
    public Lawsuits lawsuits;
 
    void Start()
    {
        lawsuits = JsonUtility.FromJson<Lawsuits>(lawsuitJson.text);
    }

    void GenerateLawsuit(){
        int lawsuitNo = UnityEngine.Random.Range(0, lawsuits.lawsuits.Length);
        string lawsuitInfo = lawsuits.lawsuits[lawsuitNo].details;

        // use above data to put in your lawsuit
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
    public string details;
}
