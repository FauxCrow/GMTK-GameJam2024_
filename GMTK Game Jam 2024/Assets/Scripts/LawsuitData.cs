using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Lawsuit")]
public class LawsuitData : ScriptableObject
{
    [TextArea(7,100)]
    [SerializeField] string lawsuitDetails;
    [SerializeField] int payoffValue, fightInCourtValue;

    public string LawsuitDetails {get {return lawsuitDetails;} private set{}}
    public int FightValue {get {return fightInCourtValue;} private set{}}
    public int PayoffValue {get {return payoffValue;} private set{}}
}