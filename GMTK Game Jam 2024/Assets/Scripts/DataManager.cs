using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.TerrainTools;
using UnityEngine;

// stores game variables across scenes
public class DataManager : MonoBehaviour
{
    // stores all variables
    public float Money { get; set; }
    public float Morality { get; set; }
    public float Reputation { get; set; }
    public int Licenses { get; set; }
    public int PillPrice { get; set; }

    public GameObject SignaturePrefab;
    public Sprite SignatureSprite;

    // store UI sliders
    public SliderBar moneyBar;
    public SliderBar moralityBar;
    public SliderBar reputationBar;

    [SerializeField] PillManager pillManager;


    // function: sets all variables to starting number
    public void Reset(){
        Money = 100;
        Morality = 100;
        Reputation = 100;
        Licenses = 0;
        PillPrice = 20;
    }

    // every 10 licenses, change offset amount
    int Offset(int variable, int value, int fraction){
        int offset = Mathf.RoundToInt(variable/fraction);
        return value - offset;
    }

    // Guard Function: ensure maximum / minimum on variables
    void CheckMinMax(){
        Money = Mathf.Clamp(Money, 0, Mathf.Infinity);
        Morality = Mathf.Clamp(Morality, 0, 100);
        Reputation = Mathf.Clamp(Reputation, 0 ,100);
    }

    // function: buy drugs woo
    // balancing -- currently, pill price increases at a flat rate of 20 per purchase
    public void BuyPill(){
        if (Money > PillPrice) {
            Money -= PillPrice;
            moneyBar.StartUpdate();

            PillPrice += 20;
            pillManager.SpawnPill();    // manages pill queue
        }
    }

    // function: increase morality when pill is popped (we love drugs)
    // balancing -- currently, minus 1 morality earned every 10 licenses approved, at 500 licenses pills do nothing
    public void RestoreMorality(){
        Morality += Offset(Licenses, 50, 10);     // max restored amount, no. of licenses before change
        
        CheckMinMax();
        
        moralityBar.StartUpdate();
    }

    // function: restore reputation when lawsuit is quietly paid off
    // balancing -- currently minus 1 reputaton restored every 20 licences approved, at 400 licenses paying off lawsuits does nothing
    void PayLawsuit(){
        if (Money > 5000){
            Money -= 5000;
            Reputation += Offset(Licenses, 20, 20);   // max restored amount, no. of licenses before change

            CheckMinMax();

            moneyBar.StartUpdate();
            reputationBar.StartUpdate();
        }
    }

    // function: decrease reputation when lawsuit makes it to court
    // balancing -- currently minus 1 reputaton removed every 20 licences approved, at 400 licenses fighting lawsuits does nothing
    void FightLawsuit(){
        if (Money > 1000){
            Money -= 1000;
            Reputation -= Offset(Licenses, 20, 20);         // max decreased amount, no. of licenses before change

            CheckMinMax();

            moneyBar.StartUpdate();
            reputationBar.StartUpdate();
        }
    }

    // function: set values when license is accepted
    // +/- should be included when function is called
    void AcceptLicense(int moneyChange, int moralityChange, int reputationChange){
        Money += moneyChange;
        Morality += moralityChange;
        Reputation += reputationChange;

        CheckMinMax();

        moneyBar.StartUpdate();
        moralityBar.StartUpdate();
        reputationBar.StartUpdate();

        Licenses++;
    }

    public void SpawnSignature(){
        GameObject signature = Instantiate(SignaturePrefab);
        signature.GetComponent<SpriteRenderer>().sprite = SignatureSprite;
    }
}
